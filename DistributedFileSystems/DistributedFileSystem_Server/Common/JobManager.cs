using FileCenter.Job;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace FileCenter.Common
{
    public class JobManager
    {
        private static JobManager jobManager;
        private static readonly object locker = new object();
        private IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;

        // 定义私有构造函数，使外界不能创建该类实例
        private JobManager()
        {
        }

        //定义公有方法提供一个全局访问点。
        public static JobManager GetInstance()
        {
            //这里的lock其实使用的原理可以用一个词语来概括“互斥”这个概念也是操作系统的精髓
            //其实就是当一个进程进来访问的时候，其他进程便先挂起状态
            if (jobManager == null)//区别就在这里
            {
                lock (locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (jobManager == null)
                    {
                        jobManager = new JobManager();
                    }
                }
            }
            return jobManager;
        }

        internal void Shutdown()
        {
            scheduler.Shutdown();

            LogHelper.Info("shutdown the scheduler");
        }

        /// <summary>
        /// 启用配置的Job
        /// </summary>
        public void Enable()
        {
            LogHelper.Info("build the scheduler");

            var jobDetailList = new List<IJobDetail>();
            var jobTypes = Assembly.GetExecutingAssembly().GetTypes().Where(
                s => s.GetInterfaces().Contains(typeof(IJob))
                &&
                s.GetCustomAttribute<JobIsIgnoredAttribute>() == null).ToList();

            LogHelper.Info($"get jobTypes total:{jobTypes.Count}");

            for (int i = 0; i < jobTypes.Count(); i++)
            {
                var jobType = jobTypes[i];
                var jobDetail = JobBuilder.Create(jobType).WithIdentity(jobType.Name, Assembly.GetExecutingAssembly().GetName().Name).Build();

                LogHelper.Info($"build the jobDetail for job:{jobType.Name}");

                // 表达式从AppConfig类中获取，匹配规则，ScheduleExpressionOf{Job类名}
                var scheduleExpression = typeof(AppConfig).GetField($"ScheduleExpressionOf{jobType.Name}").GetValue(null).ToString();

                LogHelper.Info($"get the scheduleExpression for this job:{scheduleExpression}");

                // build the trigger
                var trigger = TriggerBuilder.Create()
                                    .WithIdentity($"Trigger_{i}", Assembly.GetExecutingAssembly().GetName().Name)
                                    .WithCronSchedule(scheduleExpression)
                                    .StartNow()
                                    .Build();

                scheduler.ScheduleJob(jobDetail, trigger);

                LogHelper.Info($"schedule this job succeed");
            }

            // start the scheduler
            scheduler.Start();
        }

        private List<IJobDetail> GetJobDetailList()
        {
            var jobDetailList = new List<IJobDetail>();

            var jobTypes = Assembly.GetExecutingAssembly().GetTypes().Where(s => s.GetInterfaces().Contains(typeof(IJob)));

            foreach (var jobType in jobTypes)
            {
                var jobDetail = JobBuilder.Create(jobType).WithIdentity(jobType.Name, Assembly.GetExecutingAssembly().GetName().Name).Build();

                jobDetailList.Add(jobDetail);
            }

            return jobDetailList;
        }
    }
}