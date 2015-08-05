using System.Text;
using ImageResizer;

namespace Util.Images {
    /// <summary>
    /// 图片
    /// </summary>
    public class Image {
        /// <summary>
        /// 宽度
        /// </summary>
        public int? Width { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        public int? Height { get; set; }
        /// <summary>
        /// 源图片宽度
        /// </summary>
        public int? SourceWidth { get; set; }
        /// <summary>
        /// 源图片高度
        /// </summary>
        public int? SourceHeight { get; set; }

        /// <summary>
        /// 创建缩略图
        /// </summary>
        /// <param name="sourcePath">源图片路径，可以是绝对或相对路径</param>
        /// <param name="descPath">目标图片路径，可以是绝对或相对路径</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        public static Image CreateThumb( string sourcePath, string descPath, int width, int height ) {
            StringBuilder query = new StringBuilder();
            query.AppendFormat( "width={0}&height={1}", width,height );
            return CreateThumb( sourcePath, descPath, query.ToString() );
        }

        /// <summary>
        /// 创建缩略图
        /// </summary>
        /// <param name="sourcePath">源图片路径，可以是绝对或相对路径</param>
        /// <param name="descPath">目标图片路径，可以是绝对或相对路径</param>
        /// <param name="query">查询字符串参数，格式：参数1=值1&amp;参数2=值2 .参数：(1) width，表示宽度 (2)height,表示高度
        /// (3) format,图片扩展名，可选值：png,jpg,gif,bmp
        /// </param>
        public static Image CreateThumb( string sourcePath, string descPath, string query ) {
            ImageResizer.Configuration.Config config = new ImageResizer.Configuration.Config();
            Instructions instructions = new Instructions( query );
            ImageJob imageJob = new ImageJob( sourcePath, descPath, instructions );
            config.CurrentImageBuilder.Build( imageJob );
            imageJob.Build();
            var image = new Image() {
                Width = instructions.Width,
                Height = instructions.Height,
                SourceWidth = imageJob.SourceWidth,
                SourceHeight = imageJob.SourceHeight
            };
            return image;
        }
    }
}
