using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Pocketo.Common;

namespace Pocketo.Content
{
    public class PocketItem
    {
        [JsonConverter(typeof(StringLongConverter))]
        public long item_id;

        [JsonConverter(typeof(StringLongConverter))]
        public long resolved_id;

        public String given_url;
        public String given_title;

        [JsonConverter(typeof(StringIntConverter))]
        public int favourite;

        [JsonConverter(typeof(StringIntConverter))]
        public int status;

        [JsonConverter(typeof(StringLongConverter))]
        public long time_added;

        [JsonConverter(typeof(StringLongConverter))]
        public long time_updated;

        [JsonConverter(typeof(StringIntConverter))]
        public int time_read;

        [JsonConverter(typeof(StringIntConverter))]
        public int time_favourited;

        [JsonConverter(typeof(StringIntConverter))]
        public int sort_id;
        public String resolved_title;
        public String resolved_url;
        public String excerpt;

        [JsonConverter(typeof(StringIntConverter))]
        public int is_article;

        [JsonConverter(typeof(StringIntConverter))]
        public int is_index;

        [JsonConverter(typeof(StringIntConverter))]
        public int has_image;

        [JsonConverter(typeof(StringIntConverter))]
        public int has_video;

        [JsonConverter(typeof(StringIntConverter))]
        public int word_count;

        public Dictionary<String, Author> authors;
        public Image image;
        public Dictionary<String, Image> images;
        public Dictionary<String, Tag> tags;

    }

    public class Image
    {
        [JsonConverter(typeof(StringLongConverter))]
        public long item_id;

        [JsonConverter(typeof(StringIntConverter))]
        public int image_id;

        public String src;

        [JsonConverter(typeof(StringIntConverter))]
        public int width;

        [JsonConverter(typeof(StringIntConverter))]
        public int height;
        public String credit;
        public String caption;
    }

    public class Author
    {
        [JsonConverter(typeof(StringLongConverter))]
        public long item_id;

        [JsonConverter(typeof(StringLongConverter))]
        public long author_id;

        public String name;
        public String url;
    }

    public class Tag
    {
        [JsonConverter(typeof(StringLongConverter))]
        public long item_id;

        public String tag;
    }
}
