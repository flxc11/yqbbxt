//=========================================================================  
// CopyRight (C) 2005-2014 温州市捷点信息技术有限公司 All Rights Reserved.  
//=========================================================================  
using System;
using System.Text;
using System.ComponentModel;
using CNVP.Framework.DataAccess;
using CNVP.Framework.Utils;

namespace CNVP.Model
{
    [Description("散装货物运输表")]
    [Key("Id")]
    public class BulkFreight : DbUtils<BulkFreight>
    {
        private int? _Id = null;
        /// <summary>  
        /// Id  
        /// </summary>  
        /// <returns></returns>  
        [Description("Id")]
        public int? Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this._Id = value;
            }
        }
        private string _AppGuid = null;
        /// <summary>  
        /// 申请单AppGuid  
        /// </summary>  
        /// <returns></returns>  
        [Description("申请单AppGuid")]
        public string AppGuid
        {
            get
            {
                return this._AppGuid;
            }
            set
            {
                this._AppGuid = value;
            }
        }
        private string _BfGoodsName = null;
        /// <summary>  
        /// 散装货物运输名称  
        /// </summary>  
        /// <returns></returns>  
        [Description("散装货物运输名称")]
        public string BfGoodsName
        {
            get
            {
                return this._BfGoodsName;
            }
            set
            {
                this._BfGoodsName = value;
            }
        }
        private string _BfGoodsGroup = null;
        /// <summary>  
        /// 组别  
        /// </summary>  
        /// <returns></returns>  
        [Description("组别")]
        public string BfGoodsGroup
        {
            get
            {
                return this._BfGoodsGroup;
            }
            set
            {
                this._BfGoodsGroup = value;
            }
        }
        private string _Class = null;
        /// <summary>  
        /// 类别  
        /// </summary>  
        /// <returns></returns>  
        [Description("类别")]
        public string Class
        {
            get
            {
                return this._Class;
            }
            set
            {
                this._Class = value;
            }
        }
        private string _DangerousNo = null;
        /// <summary>  
        /// 危规编号  
        /// </summary>  
        /// <returns></returns>  
        [Description("危规编号")]
        public string DangerousNo
        {
            get
            {
                return this._DangerousNo;
            }
            set
            {
                this._DangerousNo = value;
            }
        }
        private string _BfTotalWeight = null;
        /// <summary>  
        /// 总重量  
        /// </summary>  
        /// <returns></returns>  
        [Description("总重量")]
        public string BfTotalWeight
        {
            get
            {
                return this._BfTotalWeight;
            }
            set
            {
                this._BfTotalWeight = value;
            }
        }
        private string _DischargingPort = null;
        /// <summary>  
        /// 卸货港  
        /// </summary>  
        /// <returns></returns>  
        [Description("卸货港")]
        public string DischargingPort
        {
            get
            {
                return this._DischargingPort;
            }
            set
            {
                this._DischargingPort = value;
            }
        }
        private string _Position = null;
        /// <summary>  
        /// 装载位置  
        /// </summary>  
        /// <returns></returns>  
        [Description("装载位置")]
        public string Position
        {
            get
            {
                return this._Position;
            }
            set
            {
                this._Position = value;
            }
        }
        private string _Remark = null;
        /// <summary>  
        /// 备注  
        /// </summary>  
        /// <returns></returns>  
        [Description("备注")]
        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                this._Remark = value;
            }
        }
    }
}