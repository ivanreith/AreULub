using System;
using System.ComponentModel.DataAnnotations;

namespace AreULub.Models
{

    public class QuickReview
    {
        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(30)]
        public string UserQuesting { get; set; }
        [Required(ErrorMessage = "Please enter your first evaluation.")]
        [StringLength(1)]
        public string Quest1 { get; set; }
        [Required(ErrorMessage = "Please enter your second evaluation.")]
        [StringLength(1)]
        public string Quest2 { get; set; }
        [Required(ErrorMessage = "Please enter your third evaluation.")]
        [StringLength(1)]
        public string Quest3 { get; set; }

        public string Quest2AnswerRight { get; set; }
        //public string Quest2 { get; set; }

        public string CheckQuiz(QuickReview model)
        {
           

            int totalResults = Convert.ToInt32(model.Quest1) + Convert.ToInt32(model.Quest2) + Convert.ToInt32(model.Quest3);


            if (totalResults < 6)
            {
                model.Quest2AnswerRight = "Sorry we didn't match your expectations!";
            }
            else
            {
                model.Quest2AnswerRight = "We are glad that you enjoyed our service, please come back!";
            }
           


            return totalResults.ToString();
        }
    }



}
