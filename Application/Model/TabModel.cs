﻿using Application.Attributes;


namespace Application.Model
{

        public class TabModel
        {
            public int _id { get; set; }

            public int? parentId { get; set; }

            public string path { get; set; }

            public string name { get; set; }

        [FullPathValidation(ErrorMessage = "Invalid fullPath. Please provide a valid rooted file path.")]
        public string fullPath { get; set; }

        }
    }