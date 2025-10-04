using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Intro to C#", "Imegi Nmeri Zephaniah", 300);
        Video video2 = new Video("Learn Python in 10 Minutes", "Imegi Nmeri Zephaniah", 600);
        Video video3 = new Video("Mastering Java OOP", "Imegi Nmeri Zephaniah", 900);

        // Add comments to video1
        video1.AddComment(new Comment("Emma", "Very helpful tutorial!"));
        video1.AddComment(new Comment("Noah", "I learned a lot."));
        video1.AddComment(new Comment("Sophia", "Please make more videos like this."));

        // Add comments to video2
        video2.AddComment(new Comment("Liam", "Great overview of Python basics."));
        video2.AddComment(new Comment("Olivia", "This was super fast, but I loved it!"));
        video2.AddComment(new Comment("Mason", "Now I feel confident to start coding."));

        // Add comments to video3
        video3.AddComment(new Comment("Isabella", "Java is tough but this helped."));
        video3.AddComment(new Comment("Ethan", "Can you do one on interfaces?"));
        video3.AddComment(new Comment("Ava", "Thanks for explaining so clearly."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video details
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"   {comment.Name}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40)); // separator
        }
    }
}