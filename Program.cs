using System;

public class HTMLDocument
{
    public string Head { get; private set; }
    public string Body { get; private set; }
    public string Styles { get; private set; }
    public string Scripts { get; private set; }

    public HTMLDocument()
    {
        Head = "";
        Body = "";
        Styles = "";
        Scripts = "";
    }

    public override string ToString()
    {
        return $"<!DOCTYPE html>\n<html>\n<head>\n{Head}\n{Styles}\n</head>\n<body>\n{Body}\n{Scripts}\n</body>\n</html>";
    }
}

public class HTMLBuilder
{
    private readonly HTMLDocument _document;

    public HTMLBuilder()
    {
        _document = new HTMLDocument();
    }

    // Додаємо заголовок
    public HTMLBuilder AddTitle(string title)
    {
        _document.Head += $"<title>{title}</title>\n";
        return this; // Повертаємо this для можливості ланцюгових викликів
    }

    // Додаємо мета-тег
    public HTMLBuilder AddMeta(string name, string content)
    {
        _document.Head += $"<meta name=\"{name}\" content=\"{content}\"/>\n";
        return this;
    }

    // Додаємо стиль
    public HTMLBuilder AddStyle(string style)
    {
        _document.Styles += $"<style>{style}</style>\n";
        return this;
    }

    // Додаємо скрипт
    public HTMLBuilder AddScript(string script)
    {
        _document.Scripts += $"<script>{script}</script>\n";
        return this;
    }

    // Додаємо вміст в <body>
    public HTMLBuilder AddBodyContent(string content)
    {
        _document.Body += $"{content}\n";
        return this;
    }

    // Завершуємо будівництво і повертаємо результат
    public HTMLDocument Build()
    {
        return _document;
    }
}

class Program
{
    static void Main()
    {
        var builder = new HTMLBuilder();
        var htmlDoc = builder
            .AddTitle("Мій HTML-документ")
            .AddMeta("author", "Я")
            .AddStyle("body { font-family: Arial; }")
            .AddScript("console.log('Hello World');")
            .AddBodyContent("<h1>Привіт, світ!</h1>")
            .Build();

        Console.WriteLine(htmlDoc);
    }
}
