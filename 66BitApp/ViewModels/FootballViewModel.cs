using System.Collections.Generic;
using _66BitApp.Models;

namespace _66BitApp.ViewModels
{
    public class FootballViewModel
    {
        public FootballViewModel(List<Footballer> footballers, List<Team> teams, PageViewModel pageViewModel)
        {
            Footballers = footballers;
            Teams = teams;
            PageViewModel = pageViewModel;
        }

        public List<Footballer> Footballers { get; set; }
        public List<Team> Teams { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
