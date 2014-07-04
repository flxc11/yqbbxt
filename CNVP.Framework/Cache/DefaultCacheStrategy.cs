﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Caching;
using System.Collections;
using System.Web;

namespace CNVP.Framework.Cache
{
    public class DefaultCacheStrategy : ICacheStrategy
    {
        protected static volatile System.Web.Caching.Cache WebCache = System.Web.HttpRuntime.Cache;
        /// <summary>
        /// 默认缓存存活期为3600秒(1小时)
        /// </summary>
        protected int _TimeOut = 3600;
        private static object syncObj = new object();
        /// <summary>
        /// 构造函数
        /// </summary>
        static DefaultCacheStrategy()
        {
        }
        /// <summary>
        /// 设置到期相对时间[单位: 秒] 
        /// </summary>
        public virtual int TimeOut
        {
            set { _TimeOut = value > 0 ? value : 3600; }
            get { return _TimeOut > 0 ? _TimeOut : 3600; }
        }
        /// <summary>
        /// 定义文件缓存对象
        /// </summary>
        public static System.Web.Caching.Cache GetWebCacheObj
        {
            get { return WebCache; }
        }
        /// <summary>
        /// 加入当前对象到缓存中
        /// </summary>
        /// <param name="objId">对象的键值</param>
        /// <param name="o">缓存的对象</param>
        public virtual void AddObject(string objId, object o)
        {
            if (objId == null || objId.Length == 0 || o == null)
            {
                return;
            }

            if (TimeOut == 7200)
            {
                WebCache.Insert(objId, o, null, DateTime.MaxValue, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
            }
            else
            {
                WebCache.Insert(objId, o, null, DateTime.Now.AddSeconds(TimeOut), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.High, null);
            }
        }
        /// <summary>
        /// 加入当前对象到缓存中
        /// </summary>
        /// <param name="objId">对象的键值</param>
        /// <param name="o">缓存的对象</param>
        /// <param name="o">到期时间,单位:秒</param>
        public virtual void AddObject(string objId, object o, int expire)
        {
            if (objId == null || objId.Length == 0 || o == null)
            {
                return;
            }
            //表示永不过期
            if (expire == 0)
            {
                WebCache.Insert(objId, o, null, DateTime.MaxValue, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.High, null);
            }
            else
            {
                WebCache.Insert(objId, o, null, DateTime.Now.AddSeconds(expire), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.High, null);
            }
        }
        /// <summary>
        /// 加入当前对象到缓存中,并对相关文件建立依赖
        /// </summary>
        /// <param name="objId">对象的键值</param>
        /// <param name="o">缓存的对象</param>
        /// <param name="files">监视的路径文件</param>
        public virtual void AddObjectWithFileChange(string objId, object o, string[] files)
        {
            if (objId == null || objId.Length == 0 || o == null)
            {
                return;
            }
            CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(onRemove);
            CacheDependency dep = new CacheDependency(files, DateTime.Now);
            WebCache.Insert(objId, o, dep, System.DateTime.Now.AddSeconds(TimeOut), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.High, callBack);
        }
        /// <summary>
        /// 加入当前对象到缓存中,并使用依赖键
        /// </summary>
        /// <param name="objId">对象的键值</param>
        /// <param name="o">缓存的对象</param>
        /// <param name="dependKey">依赖关联的键值</param>
        public virtual void AddObjectWithDepend(string objId, object o, string[] dependKey)
        {
            if (objId == null || objId.Length == 0 || o == null)
            {
                return;
            }
            CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(onRemove);
            CacheDependency dep = new CacheDependency(null, dependKey, DateTime.Now);
            WebCache.Insert(objId, o, dep, System.DateTime.Now.AddSeconds(TimeOut), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.High, callBack);
        }
        /// <summary>
        /// 建立回调委托的一个实例
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="reason"></param>
        public void onRemove(string key, object val, CacheItemRemovedReason reason)
        {
            switch (reason)
            {
                case CacheItemRemovedReason.DependencyChanged:
                    break;
                case CacheItemRemovedReason.Expired:
                    break;
                case CacheItemRemovedReason.Removed:
                    break;
                case CacheItemRemovedReason.Underused:
                    break;
                default: break;
            }
        }
        /// <summary>
        /// 删除缓存对象
        /// </summary>
        /// <param name="objId">对象的关键字</param>
        public virtual void RemoveObject(string objId)
        {
            if (objId == null || objId.Length == 0)
            {
                return;
            }
            WebCache.Remove(objId);
        }
        /// <summary>
        /// 返回一个指定的对象
        /// </summary>
        /// <param name="objId">对象的关键字</param>
        /// <returns>对象</returns>
        public virtual object RetrieveObject(string objId)
        {
            if (objId == null || objId.Length == 0)
            {
                return null;
            }
            return WebCache.Get(objId);
        }
        /// <summary>
        /// 清空的有缓存数据
        /// </summary>
        public virtual void FlushAll()
        {
            IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                WebCache.Remove(CacheEnum.Key.ToString());
            }
        }
    }
}