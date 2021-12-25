using System;
using System.ComponentModel.DataAnnotations;
using Amazon.DynamoDBv2.DataModel;

namespace PersonalBlog.Models
{
    [DynamoDBTable(tableName:"blog")]
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid().ToString();
            PostDateTime = DateTime.Now;
        }

        [DynamoDBHashKey]
        public string Id { get; set; } 
        public DateTime PostDateTime { get; set; }

        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
