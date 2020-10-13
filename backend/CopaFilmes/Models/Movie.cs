﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CopaFilmes.Models
{
    public class Movie: IComparable
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("titulo")]
        public string Title { get; set; }

        [JsonProperty("ano")]
        public int Year { get; set; }

        [JsonProperty("nota")]
        public decimal Rating { get; set; }

        public int CompareTo(object obj)
        {
            if (obj is Movie m)
            {
                return Title.CompareTo(m.Title);
            }
            throw new ArgumentException("obj must be of type Movie");
        }
    }
}
