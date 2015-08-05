using System.ComponentModel.DataAnnotations;

namespace Util.Webs.Ext.Tests.Forms.Samples {
    /// <summary>
    /// 用户
    /// </summary>
    public class User {
        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        [Required( ErrorMessageResourceType = typeof( TestResource ), ErrorMessageResourceName = "UserNameIsEmpty" )]
        public string Name { get; set; }
    }
}
