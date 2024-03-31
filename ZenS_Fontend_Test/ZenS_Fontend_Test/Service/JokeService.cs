using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZenS_Fontend_Test.Models;

namespace ZenS_Fontend_Test.Service
{
    public class JokeService
    {
        public JokeService() { }

        public static void InitalJoke() 
        { 
            Joke joke1 = new Joke() { Title = "Joke1", Content = "A child asked his father, \"How were people born?\" So his father said, \"Adam and Eve made babies, then their babies became adults and made babies, and so on.\"\r\n\r\nThe child then went to his mother, asked her the same question and she told him, \"We were monkeys then we evolved to become like we are now.\"\r\n\r\nThe child ran back to his father and said, \"You lied to me!\" His father replied, \"No, your mom was talking about her side of the family.\"" };
            Joke joke2 = new Joke() { Title = "Joke2", Content = "Teacher: \"Kids,what does the chicken give you?\" Student: \"Meat!\" Teacher: \"Very good! Now what does the pig give you?\" Student: \"Bacon!\" Teacher: \"Great! And what does the fat cow give you?\" Student: \"Homework!\"" };
            Joke joke3 = new Joke() { Title = "Joke3", Content = "The teacher asked Jimmy, \"Why is your cat at school today Jimmy?\" Jimmy replied crying, \"Because I heard my daddy tell my mommy, 'I am going to eat that pussy once Jimmy leaves for school today!'\"" };
            Joke joke4 = new Joke() { Title = "Joke4", Content = "A housewife, an accountant and a lawyer were asked \"How much is 2+2?\" The housewife replies: \"Four!\". The accountant says: \"I think it's either 3 or 4. Let me run those figures through my spreadsheet one more time.\" The lawyer pulls the drapes, dims the lights and asks in a hushed voice, \"How much do you want it to be?\"" };

            DataProvider.Ins.DB.Jokes.Add(joke1);
            DataProvider.Ins.DB.Jokes.Add(joke2);
            DataProvider.Ins.DB.Jokes.Add(joke3);
            DataProvider.Ins.DB.Jokes.Add(joke4);

            DataProvider.Ins.DB.SaveChanges();
        }


        public static Joke GetNextJoke(int currentJokeId = 0)
        {
            var listJoke = DataProvider.Ins.DB.Jokes.ToList();

            var joke = DataProvider.Ins.DB.Jokes.Where(x => x.Id == currentJokeId + 1).FirstOrDefault();

            if (joke == null)
            {
                return AlertEndJoke();
            }
            else
            {
                Joke returnJoke = new Joke() { Id = joke.Id, Title = joke.Title, Content = joke.Content }; 
                return returnJoke;
            }
        }

        public static bool isView(int jokeId)
        {
            if (DataProvider.Ins.DB.ViewJokes.Where(x=>x.JokeId == jokeId).FirstOrDefault() != null)
            {
                return true;
            }

            return false;
        }

        public static bool Vote(int jokeId, bool like = false)
        {
            ViewJoke viewedJoke = new ViewJoke() { JokeId = jokeId, ViewTime = DateTime.Now, Like = like };

            try
            {
                if (jokeId != -1)
                {
                    DataProvider.Ins.DB.ViewJokes.Add(viewedJoke);
                }

                DataProvider.Ins.DB.SaveChanges();

                return true;
            }
            catch
            {

            }

            return false;
        }

        public static Joke AlertEndJoke()
        {
            return new Joke() { Id = -1, Title = "alert", Content = "That's all the jokes for today! Come back another day!" };
        }
    }
}