using System;

namespace Unit3Examples
{
    // SOCIAL MEDIA POST CODE
    // string myText = "Hello world";
    // var theDate = new DateTime(2010, 6, 29);
    // var firstPost = new SocialMediaPost(myText, theDate, 5);


    // firstPost.PrintPostDetails();
    // firstPost.Like();
    // firstPost.PrintPostDetails();

    // var secondPost = new SocialMediaPost();
    // secondPost.PrintPostDetails();

    // var thirdPost = new SocialMediaPost("This is another post!");
    // thirdPost.PrintPostDetails();
    
    public class SocialMediaPost {
        //Constructor
        public SocialMediaPost() {
            text = "This is a sample post";
            timeOfPost = DateTime.UtcNow;
            numberOfLikes = 1;
        }

        public SocialMediaPost(string textArgument) {
            text = textArgument;
            timeOfPost = DateTime.Now;
            numberOfLikes = 0;
        }

        public SocialMediaPost(string textArgument, DateTime timeOfPostArgument, int numberOfLikesArgument) {
            text = textArgument;
            timeOfPost = timeOfPostArgument;
            numberOfLikes = numberOfLikesArgument;
        }


        // Data
        private string text;
        private DateTime timeOfPost;
        private int numberOfLikes;

        // Methods
        public void PrintPostDetails() {
            Console.WriteLine($"Text: {text}");
            Console.WriteLine($"Time of post: {timeOfPost}");
            Console.WriteLine($"Number of likes: {numberOfLikes}\n");
        }

        public void Like() {
            Console.WriteLine("Somebody liked this post!\n");
            numberOfLikes++;
        }
    }

}
