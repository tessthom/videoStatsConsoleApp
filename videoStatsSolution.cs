namespace Videos
{
    internal class tessThomas
    {
        // method that asks the user for a number of videos between 1-9, validates and returns input
        public static int getNumVideos()
        {
            // local variable
            int num;

            do // display prompt for number of videos and validate input
            {
                Console.Write("\nEnter an amount of videos to analyze (min: 1 - max: 9): ");

                // get input
                num = Convert.ToInt32(Console.ReadLine());

                // display error message if input invalid
                if ((num < 1) || (num > 9))
                {
                    Console.WriteLine("\nERROR: ENTER BETWEEN 1 AND 9 VIDEOS. PLEASE TRY AGAIN");
                }
            } while ((num < 1) || (num > 9)); // reiterate prompt if input invalid

            // return valid input
            return num;
        }

        // method that generates a random amount of views for each video, up to 100,000,000,000
        public static long generateViews()
        {
            // random object
            Random rand = new Random();

            // return random positive number up to 100,000,000,000
            return rand.NextInt64(100000000001);
        }

        // method that generates a random amount of likes for each video, based on the number of views
        public static long generateLikes(long views)
        {
            // random object
            Random rand = new Random();

            // return random amount of likes between 0 - number of views
            return rand.NextInt64(views + 1);
        }

        // method that accepts the amount of views and likes for a video,
        // calculates and returns the percentage of views that are likes
        public static double calculateLikePct(long views, long likes)
        {
            // return percentage of likes
            return (Convert.ToDouble(likes)) / (Convert.ToDouble(views));
        }

        // method that accepts the parallel views, likes and likePercentages arrays and number of videos
        // and displays the video number followed by its stats
        public static void displayStats(long[] views, long[] likes, double[] pcts, int numVideos)
        {
            // display stats header
            Console.WriteLine("\nVideo #\t\t\tViews\t\t\tLikes\t\t\tLike %");
            
            // display video number, amount of views and likes for each video
            for (int i = 0; i < numVideos; i++)
            {
                // output
                Console.WriteLine("Video #{0}\t\t{1}\t\t{2}\t\t{3}", (i + 1), views[i].ToString("n0"), likes[i].ToString("n0"), pcts[i].ToString("p2"));
            }
        }

        // method that accepts the views array and number of videos parameters,
        // calculates and displays the video with the most views
        public static void maxViews(long[] views, int numVideos)
        {
            // local variables
            long maxViews = views[0];
            int vidIndex = 0;

            // step through array to find video with the most views
            for (int i = 1; i < numVideos; i++)
            {
                if (views[i] > maxViews)
                {
                    maxViews = views[i]; // update the max
                    vidIndex = i + 1;
                }
            }

            // display most viewed video
            Console.WriteLine("\nMost Viewed Video");
            Console.WriteLine("Video #{0}\t{1} views", vidIndex.ToString(), maxViews.ToString("n0"));
        }

        // method that accepts the views array and number of videos as parameters,
        // calculates and displays the video with the least views
        public static void minViews(long[] views, int numVideos)
        {
            // local variables
            long minViews = views[0];
            int vidIndex = 0;

            // step through array to find video with the least views
            for (int i = 1; i < numVideos; i++)
            {
                if (views[i] < minViews)
                {
                    minViews = views[i]; // update the min
                    vidIndex = i + 1;
                }
            }

            // display most viewed video
            Console.WriteLine("\nLeast Viewed Video");
            Console.WriteLine("Video #{0}\t{1} views", vidIndex.ToString(), minViews.ToString("n0"));
        }

        // method that accepts the likes array and number of videos as parameters,
        // calculates and displays the video with the most likes
        public static void maxLikes(long[] likes, int numVideos)
        {
            // local variables
            long maxLikes = likes[0];
            int vidIndex = 0;

            // step through array to find video with the most likes
            for (int i = 1; i < numVideos; i++)
            {
                if (likes[i] > maxLikes)
                {
                    maxLikes = likes[i]; // update the max
                    vidIndex = i + 1;
                }
            }

            // display most liked video
            Console.WriteLine("\nMost Liked Video");
            Console.WriteLine("Video #{0}\t{1} likes", vidIndex.ToString(), maxLikes.ToString("n0"));
        }

        // method that accepts the likes array and number of videos as parameters,
        // calculates and displays the video with the least likes
        public static void minLikes(long[] likes, int numVideos)
        {
            // local variables
            long minLikes = likes[0];
            int vidIndex = 0;

            // step through array to find video with the least likes
            for (int i = 1; i < numVideos; i++)
            {
                if (likes[i] < minLikes)
                {
                    minLikes = likes[i]; // update the min
                    vidIndex = i + 1;
                }
            }

            // display least liked video
            Console.WriteLine("\nLeast Liked Video");
            Console.WriteLine("Video #{0}\t{1} likes", vidIndex.ToString(), minLikes.ToString("n0"));
        }

        static void Main(string[] args)
        {
            // variables
            int numVideos; // to hold the number of videos, 1-9, chosen by the user

            // call method to ask user for the number of videos that will be selected from YouTube 
            numVideos = getNumVideos();

            // declare arrays
            long[] views = new long[numVideos]; // to hold the number of views per video
            long[] likes = new long[numVideos]; // to hold the number of likes per video
            double[] likePercentages = new double[numVideos]; // to hold the calculated percentage of likes per video

            // populate arrays
            for (int i = 0; i < numVideos; i++)
            {
                // call method to generate views per video
                views[i] = generateViews();

                // call method to generate likes per video
                likes[i] = generateLikes(views[i]);

                // call method to calculate percentage of likes per video
                likePercentages[i] = calculateLikePct(views[i], likes[i]);
            }

            // display stats for each video
            displayStats(views, likes, likePercentages, numVideos);

            // display video with the most views
            maxViews(views, numVideos);

            // display video with the least views
            minViews(views, numVideos);

            // display video with the most likes
            maxLikes(likes, numVideos);

            // display video with the least likes
            minLikes(likes, numVideos);

        }
    }
}
