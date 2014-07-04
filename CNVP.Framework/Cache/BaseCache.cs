using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace CNVP.Framework.Cache
{
    /// <summary>
    /// 站群缓存类
    /// </summary>
    public class BaseCache
    {
        private static XmlElement objectXmlMap;
        private static ICacheStrategy cs;
        private static volatile BaseCache instance = null;
        private static object lockHelper = new object();
        private static XmlDocument rootXml = new XmlDocument();

        /// <summary>
        /// 构造函数
        /// </summary>
        private BaseCache()
        {
            cs = new DefaultCacheStrategy();
            if (rootXml.HasChildNodes)
                rootXml.RemoveAll();

            objectXmlMap = rootXml.CreateElement("Cache");
            //建立内部XML文档.
            rootXml.AppendChild(objectXmlMap); 
            
        }

        /// <summary>
        /// 单体模式返回当前类的实例
        /// </summary>
        /// <returns></returns>
        public static BaseCache GetInstance()
        {
            if (instance == null)
            {
                lock (lockHelper)
                {
                    if (instance == null)
                    {
                        instance = new BaseCache();
                    }
                }
            }
            return instance;
        }    
       
        /// <summary>
        /// 在XML映射文档中的指定路径,加入当前对象信息
        /// </summary>
        /// <param name="xpath">分级对象的路径 </param>
        /// <param name="o">被缓存的对象</param>
        public virtual void AddObject(string xpath, object o)
        {
            lock (lockHelper)
            {
                //当缓存到期时间为0或负值,则不再放入缓存
                if (cs.TimeOut <= 0) return;

                //整理XPATH表达式信息
                string newXpath = PrepareXpath(xpath);
                int separator = newXpath.LastIndexOf("/");
                //找到相关的组名
                string group = newXpath.Substring(0, separator);
                //找到相关的对象
                string element = newXpath.Substring(separator + 1);

                XmlNode groupNode = objectXmlMap.SelectSingleNode(group);

                //建立对象的唯一键值, 用以映射XML和缓存对象的键
                string objectId = "";

                XmlNode node = objectXmlMap.SelectSingleNode(PrepareXpath(xpath));
                if (node != null)
                {
                    objectId = node.Attributes["objectId"].Value;
                }

                if (objectId == "")
                {
                    groupNode = CreateNode(group);
                    objectId = Guid.NewGuid().ToString();
                    //建立新元素和一个属性 for this perticular object
                    XmlElement objectElement = objectXmlMap.OwnerDocument.CreateElement(element);
                    XmlAttribute objectAttribute = objectXmlMap.OwnerDocument.CreateAttribute("objectId");
                    objectAttribute.Value = objectId;
                    objectElement.Attributes.Append(objectAttribute);
                    //为XML文档建立新元素
                    groupNode.AppendChild(objectElement);
                }
                else
                {
                    //建立新元素和一个属性 for this perticular object
                    XmlElement objectElement = objectXmlMap.OwnerDocument.CreateElement(element);
                    XmlAttribute objectAttribute = objectXmlMap.OwnerDocument.CreateAttribute("objectId");
                    objectAttribute.Value = objectId;
                    objectElement.Attributes.Append(objectAttribute);
                    //为XML文档建立新元素
                    groupNode.ReplaceChild(objectElement, node);
                }

                //向缓存加入新的对象
                cs.AddObject(objectId, o);
            }
        }

        /// <summary>
        /// 在XML映射文档中的指定路径,加入当前对象信息
        /// </summary>
        /// <param name="xpath">分级对象的路径 </param>
        /// <param name="o">被缓存的对象</param>
        /// <param name="o">到期时间,单位:秒</param>
        public virtual void AddObject(string xpath, object o, int expire)
        {
            lock (lockHelper)
            {
                //当缓存到期时间为0或负值,则不再放入缓存
                if (cs.TimeOut <= 0) return;

                //整理XPATH表达式信息
                string newXpath = PrepareXpath(xpath);
                int separator = newXpath.LastIndexOf("/");
                //找到相关的组名
                string group = newXpath.Substring(0, separator);
                //找到相关的对象
                string element = newXpath.Substring(separator + 1);

                XmlNode groupNode = objectXmlMap.SelectSingleNode(group);

                //建立对象的唯一键值, 用以映射XML和缓存对象的键
                string objectId = "";

                XmlNode node = objectXmlMap.SelectSingleNode(PrepareXpath(xpath));
                if (node != null)
                {
                    objectId = node.Attributes["objectId"].Value;
                }

                if (objectId == "")
                {
                    groupNode = CreateNode(group);
                    objectId = Guid.NewGuid().ToString();
                    //建立新元素和一个属性 for this perticular object
                    XmlElement objectElement = objectXmlMap.OwnerDocument.CreateElement(element);
                    XmlAttribute objectAttribute = objectXmlMap.OwnerDocument.CreateAttribute("objectId");
                    objectAttribute.Value = objectId;
                    objectElement.Attributes.Append(objectAttribute);
                    //为XML文档建立新元素
                    groupNode.AppendChild(objectElement);
                }
                else
                {
                    //建立新元素和一个属性 for this perticular object
                    XmlElement objectElement = objectXmlMap.OwnerDocument.CreateElement(element);
                    XmlAttribute objectAttribute = objectXmlMap.OwnerDocument.CreateAttribute("objectId");
                    objectAttribute.Value = objectId;
                    objectElement.Attributes.Append(objectAttribute);
                    //为XML文档建立新元素
                    groupNode.ReplaceChild(objectElement, node);
                }

                //向缓存加入新的对象
                cs.AddObject(objectId, o, expire);
            }
        }

        /// <summary>
        /// 在XML映射文档中的指定路径,加入当前对象信息
        /// </summary>
        /// <param name="xpath">分级对象的路径 </param>
        /// <param name="o">被缓存的对象</param>
        public virtual void AddObject(string xpath, object o, string[] files)
        {
            xpath = xpath.Replace(" ", "_SPACE_");    //如果xpath中出现空格，则将空格替换为_SPACE_
            lock (lockHelper)
            {
                //当缓存到期时间为0或负值,则不再放入缓存
                if (cs.TimeOut <= 0) return;

                //整理XPATH表达式信息
                string newXpath = PrepareXpath(xpath);
                int separator = newXpath.LastIndexOf("/");
                //找到相关的组名
                string group = newXpath.Substring(0, separator);
                //找到相关的对象
                string element = newXpath.Substring(separator + 1);

                XmlNode groupNode = objectXmlMap.SelectSingleNode(group);
                //建立对象的唯一键值, 用以映射XML和缓存对象的键
                string objectId = "";

                XmlNode node = objectXmlMap.SelectSingleNode(PrepareXpath(xpath));
                if (node != null)
                {
                    objectId = node.Attributes["objectId"].Value;
                }
                if (objectId == "")
                {
                    groupNode = CreateNode(group);
                    objectId = Guid.NewGuid().ToString();
                    //建立新元素和一个属性 for this perticular object
                    XmlElement objectElement = objectXmlMap.OwnerDocument.CreateElement(element);
                    XmlAttribute objectAttribute = objectXmlMap.OwnerDocument.CreateAttribute("objectId");
                    objectAttribute.Value = objectId;
                    objectElement.Attributes.Append(objectAttribute);
                    //为XML文档建立新元素
                    groupNode.AppendChild(objectElement);
                }
                else
                {
                    //建立新元素和一个属性 for this perticular object
                    XmlElement objectElement = objectXmlMap.OwnerDocument.CreateElement(element);
                    XmlAttribute objectAttribute = objectXmlMap.OwnerDocument.CreateAttribute("objectId");
                    objectAttribute.Value = objectId;
                    objectElement.Attributes.Append(objectAttribute);
                    //为XML文档建立新元素
                    groupNode.ReplaceChild(objectElement, node);
                }

                //向缓存加入新的对象
                cs.AddObjectWithFileChange(objectId, o, files);
            }
        }
        /// <summary>
        /// 取得指定XML路径下的数据项
        /// </summary>
        /// <param name="xpath">分级对象的路径</param>
        /// <returns></returns>
        public virtual object RetrieveObject(string xpath)
        {
            try
            {
                XmlNode node = objectXmlMap.SelectSingleNode(PrepareXpath(xpath));
                if (node != null)
                    return cs.RetrieveObject(node.Attributes["objectId"].Value);

                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 通过指定的路径删除缓存中的对象
        /// </summary>
        /// <param name="xpath">分级对象的路径</param>
        public virtual void RemoveObject(string xpath)
        {
            lock (lockHelper)
            {
                try
                {
                    XmlNode result = objectXmlMap.SelectSingleNode(PrepareXpath(xpath));
                    //检查路径是否指向一个组或一个被缓存的实例元素
                    if (result.HasChildNodes)
                    {
                        //删除所有对象和子结点的信息
                        XmlNodeList objects = result.SelectNodes("*[@objectId]");
                        string objectId = "";
                        foreach (XmlNode node in objects)
                        {
                            objectId = node.Attributes["objectId"].Value;
                            node.ParentNode.RemoveChild(node);
                            //删除对象
                            cs.RemoveObject(objectId);
                        }
                    }
                    else
                    {
                        //删除元素结点和相关的对象
                        string objectId = result.Attributes["objectId"].Value;
                        result.ParentNode.RemoveChild(result);
                        cs.RemoveObject(objectId);
                    }
                }
                catch//如出错误表明当前路径不存在
                { }
            }
        }

        /// <summary>
        /// 对象树形分级对象节点
        /// </summary>
        /// <param name="xpath">分级路径 location</param>
        /// <returns></returns>
        private XmlNode CreateNode(string xpath)
        {
            lock (lockHelper)
            {
                string[] xpathArray = xpath.Split('/');
                string root = "";
                XmlNode parentNode = objectXmlMap;
                //建立相关节点
                for (int i = 1; i < xpathArray.Length; i++)
                {
                    XmlNode node = objectXmlMap.SelectSingleNode(root + "/" + xpathArray[i]);
                    // 如果当前路径不存在则建立,否则设置当前路径到它的子路径上
                    if (node == null)
                    {
                        XmlElement newElement = objectXmlMap.OwnerDocument.CreateElement(xpathArray[i]);
                        parentNode.AppendChild(newElement);
                    }
                    //设置低一级的路径
                    root = root + "/" + xpathArray[i];
                    parentNode = objectXmlMap.SelectSingleNode(root);
                }
                return parentNode;
            }
        }

        /// <summary>
        /// 整理 xpath 确保 '/'被删除 is removed
        /// </summary>
        /// <param name="xpath">分级地址</param>
        /// <returns></returns>
        private string PrepareXpath(string xpath)
        {
            lock (lockHelper)
            {
                string[] xpathArray = xpath.Split('/');
                xpath = "/Cache";
                foreach (string s in xpathArray)
                {
                    if (s != "")
                    {
                        xpath = xpath + "/" + s;
                    }
                }
                return xpath;
            }
        }

        /// <summary>
        /// 加载指定的缓存策略
        /// </summary>
        /// <param name="ics"></param>
        public void LoadCacheStrategy(ICacheStrategy ics)
        {
            lock (lockHelper)
            {    
                cs = ics;
            }
        }

        /// <summary>
        /// 加载默认的缓存策略
        /// </summary>
        public void LoadDefaultCacheStrategy()
        {
            lock (lockHelper)
            {
                cs = new DefaultCacheStrategy();
            }
        }

        /// <summary>
        /// 清空的有缓存数据
        /// </summary>
        public void FlushAll()
        {
            cs.FlushAll();
        }
    }
}