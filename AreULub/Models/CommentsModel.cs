using System;
using System.ComponentModel.DataAnnotations;

namespace AreULub.Models
{
    public class CommentsModel
    {
        [Key]
        public int CommentsID { get; set; }
         [Required]
          [MaxLength(20, ErrorMessage ="Name between 1 and 20 chars")]
        public string CommentsUser { get; set; }
          [Required]
         [MaxLength(25, ErrorMessage = "Title between 1 and 25 chars")]
        public string CommentTitle { get; set; }
          [Required]
          [MaxLength(250, ErrorMessage = "storyText between 1 and 250 chars")]
        public string CommentText { get; set; }
          
        public DateTime CommentDate { get; set; }
    }
}

