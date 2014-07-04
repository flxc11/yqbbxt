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
    [Description("审批表")]
    [Key("Guid")]
    public class Accredit : DbUtils<Accredit>
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
        private string _Guid = null;
        /// <summary>  
        /// Guid  
        /// </summary>  
        /// <returns></returns>  
        [Description("Guid")]
        public string Guid
        {
            get
            {
                return this._Guid;
            }
            set
            {
                this._Guid = value;
            }
        }
        private string _AppGuid = null;
        /// <summary>  
        /// AppGuid  
        /// </summary>  
        /// <returns></returns>  
        [Description("AppGuid")]
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
        private int? _AccreditationMen = null;
        /// <summary>  
        /// AccreditationMen  
        /// </summary>  
        /// <returns></returns>  
        [Description("AccreditationMen")]
        public int? AccreditationMen
        {
            get
            {
                return this._AccreditationMen;
            }
            set
            {
                this._AccreditationMen = value;
            }
        }
        private DateTime? _AccreditationTime = null;
        /// <summary>  
        /// AccreditationTime  
        /// </summary>  
        /// <returns></returns>  
        [Description("AccreditationTime")]
        public DateTime? AccreditationTime
        {
            get
            {
                return this._AccreditationTime;
            }
            set
            {
                this._AccreditationTime = value;
            }
        }
        private string _AppOpinions = null;
        /// <summary>  
        /// 审批意见  
        /// </summary>  
        /// <returns></returns>  
        [Description("审批意见")]
        public string AppOpinions
        {
            get
            {
                return this._AppOpinions;
            }
            set
            {
                this._AppOpinions = value;
            }
        }
    }
}