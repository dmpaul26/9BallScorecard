using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _9BallScorecard.ViewModels
{
    internal class NineBallViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string playerOneName, playerTwoName;
        private int playerOneScore, playerTwoScore;
        public List<Ball> Balls;
        public int RackCount;

        public string PlayerOneName
        {
            get => playerOneName;
            set
            {
                if (playerOneName != value)
                {
                    playerOneName = value;
                    OnPropertyChanged(); // reports this property
                }
            }
        }

        public string PlayerTwoName
        {
            get => playerTwoName;
            set
            {
                if (playerTwoName != value)
                {
                    playerTwoName = value;
                    OnPropertyChanged(); // reports this property
                }
            }
        }

        public int PlayerOneScore
        {
            get => playerOneScore;
            set
            {
                if (playerOneScore != value)
                {
                    playerOneScore = value;
                    OnPropertyChanged(); // reports this property
                }
            }
        }

        public int PlayerTwoScore
        {
            get => playerTwoScore;
            set
            {
                if (playerTwoScore != value)
                {
                    playerTwoScore = value;
                    OnPropertyChanged(); // reports this property
                }
            }
        }

        public ICommand IncrementScoreCommand { get; private set; }
        public ICommand DecrementScoreCommand { get; private set; }

        public NineBallViewModel()
        {
            PlayerOneName = "Player 1";
            PlayerTwoName = "Player 2";
            PlayerOneScore = 0;
            PlayerTwoScore = 0;

            IncrementScoreCommand = new Command<string>(
                execute: (string player) =>
                {
                    if (player == "1")
                    {
                        PlayerOneScore += 1;
                    }
                    else
                    {
                        PlayerTwoScore += 1;
                    }
                });

            DecrementScoreCommand = new Command<string>(
                execute: (string player) =>
                {
                    if (player == "1")
                    {
                        if (PlayerOneScore > 0) PlayerOneScore -= 1;
                    }
                    else
                    {
                        if (PlayerTwoScore > 0) PlayerTwoScore -= 1;
                    }
                });
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public interface Ball
    {
        string Name { get; set; }
        bool OnTable { get; set; }
        int PointValue { get; set; }
    }
}
