using System;
using System.Collections.Generic;
using System.Text;
using CNVP.Framework.Aop;
using CNVP.Framework.DataAccess;
using System.Collections;

namespace CNVP.Data
{
    [Aspect]
    public class Application : ContextBoundObject
    {
        [Transaction]
        public void Add(Model.Application appli,Model.SCW scw, Model.Source source, Model.BulkFreight bulk)
        {
            appli.Insert();
            if (appli.IO==1)
            {
                scw.Insert();
            }

            //循环插入附件
            string[] picName = source.SourceUrl.Replace("|$|", "&").Split(new char[] {'&'});
            for (int i = 0; i < picName.Length - 1; i++)
            {
                string[] picUrl = picName[i].Replace("|#|", "|").Split(new char[] { '|' });
                source.SourceUrl = picUrl[1];
                source.SourceType = picUrl[0];
                source.Insert();
            }

            //循环插入散装货物列表
            string[] BfGoodsName = bulk.BfGoodsName.Split(',');
            string[] BfGoodsGroup = bulk.BfGoodsGroup.Split(',');
            string[] Class = bulk.Class.Split(',');
            string[] DangerousNo = bulk.DangerousNo.Split(',');
            string[] BfTotalWeight = bulk.BfTotalWeight.Split(',');
            string[] DischargingPort = bulk.DischargingPort.Split(',');
            string[] Position = bulk.Position.Split(',');
            string[] Remark = bulk.Remark.Split(',');
            for (int i = 0; i < BfGoodsName.Length; i++)
            {
                bulk.BfGoodsName = BfGoodsName[i];
                bulk.BfGoodsGroup = BfGoodsGroup[i];
                bulk.Class = Class[i];
                bulk.DangerousNo = DangerousNo[i];
                bulk.BfTotalWeight = BfTotalWeight[i];
                bulk.DischargingPort = DischargingPort[i];
                bulk.Position = Position[i];
                bulk.Remark = Remark[i];
                bulk.Insert();
            }
        }

        #region 编辑申请单
        [Transaction]
        /// <summary>
        /// 编辑申请单
        /// </summary>
        /// <param name="appli">项目申请单</param>
        /// <param name="scw">安全适运单</param>
        /// <param name="source">附件</param>
        /// <param name="bulk">散装货物</param>
        public void Edit(Model.Application appli,Model.SCW scw, Model.Source source1, Model.BulkFreight bulk, string bulkId)
        {
            appli.Update();
            if (appli.IO == 1)
            {
                scw.Update();
            }

            //循环更新附件
            string[] picName = source1.SourceUrl.Replace("|$|", "&").Split(new char[] { '&' });
            for (int i = 0; i < picName.Length - 1; i++)
            {
                string[] picUrl = picName[i].Replace("|#|", "|").Split(new char[] { '|' });
                source1.SourceUrl = picUrl[1];
                source1.SourceType = picUrl[0];
                Hashtable ht = new Hashtable();
                ht.Add("AppGuid", source1.AppGuid);
                ht.Add("SourceType", source1.SourceType);
                if (source1.IsExist(ht))
                {
                    source1.Update(
                        "SourceUrl='" + source1.SourceUrl + "'",
                        " and AppGuid='" + source1.AppGuid + "' and SourceType='" + source1.SourceType + "'");
                }
                else
                {
                    source1.CreateTime = DateTime.Now;
                    source1.Insert();
                }
                
            }

            //循环插入散装货物列表
            string[] BulkId = bulkId.Split(',');
            string[] BfGoodsName = bulk.BfGoodsName.Split(',');
            string[] BfGoodsGroup = bulk.BfGoodsGroup.Split(',');
            string[] Class = bulk.Class.Split(',');
            string[] DangerousNo = bulk.DangerousNo.Split(',');
            string[] BfTotalWeight = bulk.BfTotalWeight.Split(',');
            string[] DischargingPort = bulk.DischargingPort.Split(',');
            string[] Position = bulk.Position.Split(',');
            string[] Remark = bulk.Remark.Split(',');
            for (int i = 0; i < BfGoodsName.Length; i++)
            {
                bulk.BfGoodsName = BfGoodsName[i];
                bulk.BfGoodsGroup = BfGoodsGroup[i];
                bulk.Class = Class[i];
                bulk.DangerousNo = DangerousNo[i];
                bulk.BfTotalWeight = BfTotalWeight[i];
                bulk.DischargingPort = DischargingPort[i];
                bulk.Position = Position[i];
                bulk.Remark = Remark[i];
                bulk.Id = Convert.ToInt32(BulkId[i]);
                bulk.Update();
            }
        }
        #endregion

        #region 删除申请单、适运单，散装货物单
        [Transaction]
        public void ApplyDelete(Model.Application appli,Model.SCW scw, Model.BulkFreight bulk)
        {
            Hashtable ht = new Hashtable();
            ht.Add("Guid", appli.Guid);
            appli.Delete(ht);

            ht.Clear();
            ht.Add("AppGuid", appli.Guid);
            scw.Delete(ht);
            bulk.Delete(ht);
        }
        #endregion
    }
}