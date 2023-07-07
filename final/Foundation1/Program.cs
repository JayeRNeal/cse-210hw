using System;
using System.Collections.Generic;

class Program{
    static void Main(string[] args){
        //3 videos w/ comments
        Video video1 = new Video("Video 1 title", "Video 1 Author", 60);
        video1.Comments.Add(new Comment("First Commentor", "1st comment on video 1"));
        video1.Comments.Add(new Comment("Second Commentor", "2nd comment on video 1"));
        video1.Comments.Add(new Comment("Third Commentor", "3rd comment on video 1"));
        videos.Add(video1);


        Video video2 = new Video("Video 2 title", "Video 2 Author", 120);
        video2.Comments.Add(new Comment("First Commentor", "1st comment on video 2"));
        video2.Comments.Add(new Comment("Second Commentor", "2nd comment on video 2"));
        video2.Comments.Add(new Comment("Third Commentor", "3rd comment on video 2"));
        video2.Comments.Add(new Comment("Fourth Commentor", "4th comment on video 2"));
        videos.Add(video2);

        Video video3 = new Video("Video 3 title", "Video 3 Author", 180);
        video3.Comments.Add(new Comment("First Commentor", "1st comment on video 3"));
        video3.Comments.Add(new Comment("Second Commentor", "2nd comment on video 3"));
        video3.Comments.Add(new Comment("Third Commentor", "3rd comment on video 3"));
        videos.Add(video3);

        //iterate through videos & display info
        foreach (Video video in videos){
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine{$"Author: {video._author}"}; //error? says ;expected but have a ; at end of each line.
            Console.WriteLine($"Length: {video._lengthSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.NumComments()}");
            Console.WriteLine();
            Console.WriteLine("Comments: ");

            foreach (Comment comment in video.Comments) {
                Console.WriteLine($"{comment._name}: {comment._text}"); //or object value = Console.WriteLine($"{comment._name}: {comment._text}");
            }
            Console.WriteLine();
        }
    }

//Video class
class Video{
    public string _title;
    public string _author;
    public string _lengthSeconds;
    public List<Comment>Comments;

    public Video(string title, string author, int _lengthSeconds){
        _title = title;
        _author = author;
        _lengthSeconds = _lengthSeconds;
        Comments = new List<Comment>();
    }

    //returns
    public int NumComments(){
        return Comments.Count;
    }
    public string GetTitle(){
        return _title;
    }
    public string GetAuthor(){
        return _author;
    }
    public int GetLengthSeconds(){
        return _lengthSeconds;
    }
}

//Comment class
class Comment{
    public string _name;
    public string _text;

    public Comment(string name, string text){
        _name = name;
        _text = text;
    }
    public string GetName(){
        return _name;
    }
    public string GetText(){
        return _text;
    }
}
}