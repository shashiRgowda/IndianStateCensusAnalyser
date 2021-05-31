using CensusAnalyserTest;
using NUnit.Framework;
using System.Collections.Generic;

public class Tests
{
    //CensusAnalyser.CensusAnalyser censusAnalyser;

    static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
    static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
    static string indianStateCensusFilePath = @"C:\Users\amit rana\source\repos\IndianStateCensusAnalyser\censurAnalyser\Utility\IndiaStateCensusData.csv";
    static string wrongHeaderIndianCensusFilePath = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\WrongIndiaStateCensusData.csv";
    static string delimiterIndianCensusFilePath = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\DelimiterIndiaStateCensusData.csv";
    static string wrongIndianStateCensusFilePath = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\WrongIndiaStateCensusData.csv";
    static string wrongIndianStateCensusFileType = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\IndiaStateCensusData.txt";
    static string indianStateCodeFilePath = @"C:\Users\amit rana\source\repos\IndianStateCensusAnalyser\censurAnalyser\Utility\IndiaStateCode.csv";
    static string wrongIndianStateCodeFileType = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\IndiaStateCode.txt";
    static string delimiterIndianStateCodeFilePath = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\DelimiterIndiaStateCode.csv";
    static string wrongHeaderStateCodeFilePath = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\WrongIndiaStateCode.csv";

    CensusAnalyser censusAnalyser;
    Dictionary<string, CensusDTO> totalRecord;
    Dictionary<string, CensusDTO> stateRecord;

    public object Country { get; private set; }

    [SetUp]
    public void Setup()
    {
        censusAnalyser = new CensusAnalyser();
        totalRecord = new Dictionary<string, CensusDTO>();
        stateRecord = new Dictionary<string, CensusDTO>();
    }


    [Test]
    public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
    {
        totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
        stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
        Assert.AreEqual(29, totalRecord.Count);
        Assert.AreEqual(37, stateRecord.Count);
    }

    [Test]
    public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
    {
        var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
        var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
        Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
    }
}

