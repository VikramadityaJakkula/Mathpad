using System;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
//using System.Windows.Media;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using System.Xml;
namespace SilverlightMathPad
{
    public partial class QuizPage : UserControl
    {
        System.Windows.Threading.DispatcherTimer FirstTimer = new System.Windows.Threading.DispatcherTimer();

        System.Windows.Threading.DispatcherTimer SecondTimer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer TimeCount = new System.Windows.Threading.DispatcherTimer();

        SilverlightMathPad.QuizPaper quiz;
        SilverlightMathPad.Evaluator evaluatorProperty;
        SilverlightMathPad.Question q;
        int Level;
        int Score;
        int time;

        string strOption, strCategory;
        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            //TimeSpan now = DateTime.Now.TimeOfDay;

            DateTime now; // = default(DateTime);
            now = Convert.ToDateTime("00:00:00");

            now = now.AddSeconds(time);
            

            // update the time
            H1.AnimateTo(now.Hour / 10);
            H2.AnimateTo(now.Hour % 10);

            M1.AnimateTo(now.Minute / 10);
            M2.AnimateTo(now.Minute % 10);

            S1.AnimateTo(now.Second / 10);
            S2.AnimateTo(now.Second % 10);
        }
        public QuizPage()
        {

            InitializeComponent();
            
    
            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
      
            FirstTimer.Interval = new TimeSpan(0, 0, 0, 1, 500); // 500 Milliseconds  
            FirstTimer.Tick += new EventHandler(FirstTimer_Tick);

            SecondTimer.Interval = new TimeSpan(0, 0, 0, 2, 500); // 500 Milliseconds  
            SecondTimer.Tick += new EventHandler(SecondTimer_Tick);

            TimeCount.Interval = new TimeSpan(0, 0, 0, 1, 0); // 500 Milliseconds  
            TimeCount.Tick += new EventHandler(TimeCount_Tick);

            //  timer.Completed += new EventHandler(timer_Completed);
            //timerSmall.Completed += new EventHandler(timer_Completed);

        }
        private void media_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show(e.ErrorException.Message);
        }
        void TimeCount_Tick(object sender, EventArgs e)
        {

            time++;
            if (lblScore.Visibility == Visibility.Visible)
                lblScore.Visibility = Visibility.Collapsed;
            else
                lblScore.Visibility = Visibility.Visible;
            //lblTime.Content = time.ToString();
            //   TimeCount.Stop();
        }
        void SecondTimer_Tick(object sender, EventArgs e)
        {
            LoadQuestion();
            SecondTimer.Stop();
            media.Stop();
            mediaCry.Stop();
        }

        public QuizPage(string Category, string option, int Level, int Score, int Time)
            : this()
        {
            this.strOption = option;
            this.Level = Level;
            this.Score = Score;
            this.time = Time;
            this.strCategory = Category;
            btnOperation.Content = strOption;
            btnCategory.Content = strCategory;
            quiz = new SilverlightMathPad.QuizEngine().generateQuizPaper(strOption, 12, Level);
            quiz.presentQuestion = 0;
            quiz.CorrectAnswered = 0;
            quiz.questionsAnswered = 0;
            LoadQuestion();
            //lblTime.Content = Time.ToString();
        }
        void FirstTimer_Tick(object sender, EventArgs e)
        {
            if (q.answer == Ans1.Content.ToString())
            {
                Ans1.Style = (Style)this.Resources["GreenButton"];
                image1.Source = new BitmapImage(new Uri("/SilverlightMathPad;component/Images/correctImage.png", UriKind.Relative));
            }
            if (q.answer == Ans2.Content.ToString())
            {
                Ans2.Style = (Style)this.Resources["GreenButton"];
                image2.Source = new BitmapImage(new Uri("/SilverlightMathPad;component/Images/correctImage.png", UriKind.Relative));
            }
            if (q.answer == Ans3.Content.ToString())
            {
                Ans3.Style = (Style)this.Resources["GreenButton"];
                image3.Source = new BitmapImage(new Uri("/SilverlightMathPad;component/Images/correctImage.png", UriKind.Relative));
            }
            if (q.answer == Ans4.Content.ToString())
            {
                Ans4.Style = (Style)this.Resources["GreenButton"];
                image4.Source = new BitmapImage(new Uri("/SilverlightMathPad;component/Images/correctImage.png", UriKind.Relative));
            }
            FirstTimer.Stop();
        }


        void timer_Completed(object sender, EventArgs e)
        {
            //if (sender == timer)
            //    LoadQuestion();
            //else
            //{
            //    //If timerSmall, set correct anser image
            //    if (q.answer == Ans1.Content.ToString())
            //        image1.Source = new BitmapImage(new Uri("/SilverlightMathPad;component/Images/correctImage.png", UriKind.Relative));
            //    if (q.answer == Ans2.Content.ToString())
            //        image2.Source = new BitmapImage(new Uri("/SilverlightMathPad;component/Images/correctImage.png", UriKind.Relative));
            //    if (q.answer == Ans3.Content.ToString())
            //        image3.Source = new BitmapImage(new Uri("/SilverlightMathPad;component/Images/correctImage.png", UriKind.Relative));
            //    if (q.answer == Ans4.Content.ToString())
            //        image4.Source = new BitmapImage(new Uri("/SilverlightMathPad;component/Images/correctImage.png", UriKind.Relative));
            //}
            // restart the timer
            //timer.Begin();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //  Level = 0;
            //  Score = 500;
            // CreateQuiz();
            //button3.Background = new SolidColorBrush(Colors.Black);
            //button3.Foreground = new SolidColorBrush(Colors.White);
            //button3.BorderBrush = 
            // LoadQuestion();
            media.MediaFailed += new EventHandler<ExceptionRoutedEventArgs>(media_MediaFailed);
            mediaCry.MediaFailed += new EventHandler<ExceptionRoutedEventArgs>(media_MediaFailed);
        }
        private void CreateQuiz()
        {

            // Level = ;


            if ((Level + 1) > 10)
            {
                Holder holder = this.Parent as Holder;
                holder.Navigate(new GameOver(strCategory, strOption, 10, Score, time));
            }
            else
            {
                Holder holder = this.Parent as Holder;
                holder.Navigate(new Level(btnCategory.Content.ToString(), strOption, Level + 1, Score, time));

            }
        }
        private void LoadQuestion()
        {
            Ans1.Style = (Style)this.Resources["OrangeButton"];
            Ans2.Style = (Style)this.Resources["OrangeButton"];
            Ans3.Style = (Style)this.Resources["OrangeButton"];
            Ans4.Style = (Style)this.Resources["OrangeButton"];
            Ans1.IsEnabled = true;
            Ans2.IsEnabled = true;
            Ans3.IsEnabled = true;
            Ans4.IsEnabled = true;
            lblScore.Content ="Your score : " + Score.ToString(); //"Level: " + Level.ToString() + "             Your score : " + Score.ToString();
            image1.Source = null;
            image2.Source = null;
            image3.Source = null;
            image4.Source = null;
            if (quiz.presentQuestion < quiz.questionaire.Count)
            {
                q = quiz.questionaire[quiz.presentQuestion];

                Qns.Text = q.question;// quiz.questionaire[QnsNo].question;
                Ans1.Content = q.options[0];
                Ans2.Content = q.options[1];
                Ans3.Content = q.options[2];
                Ans4.Content = q.options[3];
                TimeCount.Start();
            }

            if (Score <= 0)
            {
                Holder holder = this.Parent as Holder;
                holder.Navigate(new GameOver(strCategory, strOption, Level, Score, time));


            }
            else
            {
                if (quiz.CorrectAnswered >= 10)
                {
                    if (quiz.presentQuestion == (quiz.questionaire.Count))
                    {

                        CreateQuiz();
                    }
                }
                else if (quiz.presentQuestion == (quiz.questionaire.Count - 2))
                {
                    CreateQuiz();
                }
                else
                    ;
            }
        }

        private void checkAnswer(string Answer, string Button)
        {
            Ans1.IsEnabled = false;
            Ans2.IsEnabled = false;
            Ans3.IsEnabled = false;
            Ans4.IsEnabled = false;
            TimeCount.Stop();
            quiz.questionsAnswered++;
            if (Answer == q.answer)
            {

                media.Play();

                Score = Score + 100;
                quiz.CorrectAnswered++;
                q.correct = 1;
                if (Button == "Ans1")
                {
                    Ans1.Style = (Style)this.Resources["GreenButton"];
                    image1.Source = new BitmapImage(new Uri("/SilverlightMathPad;component/Images/correctImage.png", UriKind.Relative));
                }
                if (Button == "Ans2")
                {
                    Ans2.Style = (Style)this.Resources["GreenButton"];
                    image2.Source = new BitmapImage(new Uri("/SilverlightMathPad;component/Images/correctImage.png", UriKind.Relative));
                }
                if (Button == "Ans3")
                {
                    Ans3.Style = (Style)this.Resources["GreenButton"];
                    image3.Source = new BitmapImage(new Uri("/SilverlightMathPad;component/Images/correctImage.png", UriKind.Relative));
                }
                if (Button == "Ans4")
                {
                    Ans4.Style = (Style)this.Resources["GreenButton"];
                    image4.Source = new BitmapImage(new Uri("/SilverlightMathPad;component/Images/correctImage.png", UriKind.Relative));
                }
            }
            else
            {
                mediaCry.Play();
                q.correct = 0;
                Score = Score - 100;
                if (Button == "Ans1")
                    image1.Source = new BitmapImage(new Uri("/SilverlightMathPad;component/Images/wrongImage.png", UriKind.Relative));
                if (Button == "Ans2")
                    image2.Source = new BitmapImage(new Uri("/SilverlightMathPad;component/Images/wrongImage.png", UriKind.Relative));
                if (Button == "Ans3")
                    image3.Source = new BitmapImage(new Uri("/SilverlightMathPad;component/Images/wrongImage.png", UriKind.Relative));
                if (Button == "Ans4")
                    image4.Source = new BitmapImage(new Uri("/SilverlightMathPad;component/Images/wrongImage.png", UriKind.Relative));
                FirstTimer.Start();
                //  timerSmall.Begin();
            }

            quiz.presentQuestion++;

            //  timer.Begin();
            SecondTimer.Start();
        }

        private void Ans1_Click(object sender, RoutedEventArgs e)
        {
            checkAnswer(Ans1.Content.ToString(), "Ans1");
        }

        private void Ans2_Click(object sender, RoutedEventArgs e)
        {
            checkAnswer(Ans2.Content.ToString(), "Ans2");
        }

        private void Ans3_Click(object sender, RoutedEventArgs e)
        {
            checkAnswer(Ans3.Content.ToString(), "Ans3");
        }

        private void Ans4_Click(object sender, RoutedEventArgs e)
        {
            checkAnswer(Ans4.Content.ToString(), "Ans4");
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCatgory_Click(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            switch (strCategory)
            {
                case "Basic Math":
                    holder.Navigate(new BasicMath());
                    break;
                case "Advance Math":
                    holder.Navigate(new AdvMath());
                    break;
                case "Every Day Math":
                    holder.Navigate(new EveryDayMath());
                    break;

            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Holder holder = this.Parent as Holder;
            holder.Navigate(new StartPage());
        }



    }


}
