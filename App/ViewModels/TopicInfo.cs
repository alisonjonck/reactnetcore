﻿using App.Domain.Helpers;
using App.Domain.Models;

namespace App.ViewModels
{
    public class TopicInfo
    {
        public string Value { get; set; }
        public int WordCount { get; set; }
        public int WordCountWithoutPrepositions { get; set; }
        public string ValueWithoutPrepositions { get; set; }

        public TopicInfo(FeedTopic topic)
        {
            this.Value = topic.Title;
            this.WordCount = this.countWords(topic.Title);
            this.ValueWithoutPrepositions = topic.Title.RemovePrepositions(" ");
            this.WordCountWithoutPrepositions = this.countWords(this.ValueWithoutPrepositions);
        }

        private int countWords(string text)
        {
            return text.Split(" ").Length;
        }
    }
}
