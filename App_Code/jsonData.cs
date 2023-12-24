using System.Collections.Generic;

public class jsonData
{
    public string pk { get; set; }
    public List<Article> articles { get; set; }
}


public partial class Article
{
    public string id { get; set; }
    public string articletitle { get; set; }
    public string articleauthor { get; set; }
    public string articlebody { get; set; }
    public string articleimage { get; set; }
    public string createdonutc { get; set; }
    public string modifiedonutc { get; set; }
    public string status { get; set; }
}