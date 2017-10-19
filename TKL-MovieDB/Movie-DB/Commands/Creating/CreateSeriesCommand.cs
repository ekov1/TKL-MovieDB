﻿using Movie_DB.Commands.Abstarcts;
using Movie_DB.Commands.Contracts;
using Movie_DB.Commands.Core.Factories;
using Movie_DB.Core.Providers;
using Movie_DB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Movie_DB.Commands.Creating
{
    public class CreateSeriesCommand : AbstractCommand, ICommand
    {
        private string name;
        private string genreName;
        private string ongoing;
        private int numberOfSeasons;
        private int episodesPerSeason;

        public CreateSeriesCommand(IMovieDbContext context, IMovieFactory factory, IReader reader, IWriter writer)
            : base(context, factory, reader, writer)
        {
        }

        public void CollectData()
        {
            writer.WriteLine("Enter Series Name:");
            name = reader.ReadLine();
            writer.WriteLine("Enter Series Genre:");
            genreName = reader.ReadLine();
            //writer.WriteLine("Enter Number Of Seasons:");
            //seriesData.Add(reader.ReadLine());// data 2
            //writer.WriteLine("Enter Episodes Per Season:");
            //seriesData.Add(reader.ReadLine());// data 3
            //writer.WriteLine("Enter Series ongoing status (yes/no):");
            //seriesData.Add(reader.ReadLine());// data 4
        }

        public string Execute()
        {
            CollectData();
            var genre = context.Genres.FirstOrDefault(g => g.Name == genreName);
            //if (genre == null)
            //{
            //   genre = new CreateGenreCommand(genreName);
            //}

             var series = this.factory.CreateSeries(name, genre);

             context.SeriesCollection.Add(series);

            context.SaveChanges();

            return "Series Created";
        }
    }
}
