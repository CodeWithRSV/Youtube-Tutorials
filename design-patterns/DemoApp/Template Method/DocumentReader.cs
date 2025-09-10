abstract class DataMiner
{
    public void MineData()
    {
        this.OpenFile();
        this.ExtractData();
        this.ParseData();
        this.AnalyzeData();
        this.SendReport();
        this.CloseFile();
    }
    protected void OpenFile()
    {
        Console.WriteLine("File open");
    }

    protected void AnalyzeData()
    {
        Console.WriteLine("Data analysis done");
    }

    protected void SendReport()
    {
        Console.WriteLine("Report sent");
    }

    protected void CloseFile()
    {
        Console.WriteLine("File closed");
    }
    protected abstract void ExtractData();
    protected abstract void ParseData();
}

class PDFDataMiner: DataMiner
{
    protected override void ExtractData()
    {
        Console.WriteLine("Extracted Data from pdf file");
    }

    protected override void ParseData()
    {
        Console.WriteLine("Parsed Data from pdf file");
    }
}

class DocDataMiner :DataMiner
{
    protected override void ExtractData()
    {
        Console.WriteLine("Extracted Data from doc file");
    }

    protected override void ParseData()
    {
        Console.WriteLine("Parsed Data from doc file");
    }
}
