using System;
using System.Collections.Generic;

namespace Unit3
{
    class Post {
        /*** Data members ***/
        int numLikes;
        string text;
        string username;
        List<string> hashtags;
        DateTime dateCreated;

        // Constructor
        public Post(string theText, List<string> theHashtags, string theUsername) {
            text = theText;
            hashtags = theHashtags;
            username = theUsername;
            numLikes = 0;
            dateCreated = DateTime.Now;
        }

        /*** Methods ***/
        public void Like() {
            numLikes++;
        }

        public void Unlike() {
            if (numLikes > 0) {
                numLikes--;
            } else {
                throw new Exception("Likes can't be below 0");
            }
        }

        public void PrintDetails() {
            Console.WriteLine($"Text: {text}");
            Console.WriteLine($"Number of Likes: {numLikes}");
            Console.WriteLine($"Date Created: {dateCreated}");
            Console.WriteLine($"Hashtags:");
            for (int i = 0; i < hashtags.Count; i++) {
                Console.WriteLine($"- #{hashtags[i]}");
            }
        }

    }
}