namespace Util.Webs.Ext.Controls.ProgressBars {
    /// <summary>
    /// 进度条
    /// </summary>
    public class ProgressBar : IProgressBar {
        /// <summary>
        /// 进度条文本
        /// </summary>
        private string _progressText;
        /// <summary>
        /// 内容
        /// </summary>
        private string _content;
        /// <summary>
        /// 图标class
        /// </summary>
        private string _iconClass;

        /// <summary>
        /// 设置进度条文本
        /// </summary>
        /// <param name="text">进度条文本</param>
        public IProgressBar ProgressText( string text ) {
            _progressText = text;
            return this;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="content">内容</param>
        public IProgressBar Content( string content ) {
            _content = content;
            return this;
        }

        /// <summary>
        /// 设置图标class
        /// </summary>
        /// <param name="iconClass">图标class</param>
        public IProgressBar IconClass( string iconClass ) {
            _iconClass = iconClass;
            return this;
        }

        /// <summary>
        /// 输出Html
        /// </summary>
        public string ToHtmlString() {
            Str result = new Str();
            result.Add( "Ext.Msg.show({" );
            result.Add( "wait: true," );
            result.Add( "draggable: false," );
            result.Add( "width: 300," );
            result.Add( "progressText: \"{0}\",", GetProgressText() );
            result.Add( "msg: \"{0}\",", GetContent() );
            result.Add( "icon: \"{0}\"", GetIconClass() );
            result.Add( "});" );
            return result.ToString();
        }

        /// <summary>
        /// 获取进度条文本
        /// </summary>
        private string GetProgressText() {
            if ( _progressText.IsEmpty() )
                _progressText = "请稍候..";
            return _progressText;
        }

        /// <summary>
        /// 获取内容
        /// </summary>
        private string GetContent() {
            if ( _content.IsEmpty() )
                _content = "处理中..";
            return _content;
        }

        /// <summary>
        /// 获取图标class
        /// </summary>
        private string GetIconClass() {
            if ( _iconClass.IsEmpty() )
                _iconClass = "progress-Save";
            return _iconClass;
        }
    }
}
