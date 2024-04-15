﻿using Microsoft.AspNetCore.Mvc;

namespace PSDinner.Api.Errors;

public class CustomProblemDetails : ProblemDetails
{
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}