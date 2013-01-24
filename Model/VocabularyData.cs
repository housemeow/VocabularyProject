using System;
using System.ComponentModel;


public class VocabularyData
{
    private int _id;
    private String _vocabulary;
    private DateTime _addDateTime;
    private String _chineseExplanation;
    private String _englishExplanation;
    private String _example;
    private String _chineseExample;
    private int _correctTimes;
    private int _guessTimes;
    private int _correctPercentage;
    private String _comment;

    [DisplayName("編號")]
    public int Id
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }

    [DisplayName("單字")]
    public String Vocabulary
    {
        get
        {
            return _vocabulary;
        }
        set
        {
            _vocabulary = value;
        }
    }

    [DisplayName("加入時間")]
    public DateTime AddDateTime
    {
        get
        {
            return _addDateTime;
        }
        set
        {
            _addDateTime = value;
        }
    }

    [DisplayName("中文解釋")]
    public String ChineseExplanation
    {
        get
        {
            return _chineseExplanation;
        }
        set
        {
            _chineseExplanation = value;
        }
    }

    [DisplayName("英文解釋")]
    public String EnglishExplanation
    {
        get
        {
            return _englishExplanation;
        }
        set
        {
            _englishExplanation = value;
        }
    }

    [DisplayName("例句")]
    public String Example
    {
        get
        {
            return _example;
        }
        set
        {
            _example = value;
        }
    }

    [DisplayName("例句中文解釋")]
    public String ChineseExample
    {
        get
        {
            return _chineseExample;
        }
        set
        {
            _chineseExample = value;
        }
    }

    [DisplayName("答對次數")]
    public int CorrectTimes
    {
        get
        {
            return _correctTimes;
        }
        set
        {
            _correctTimes = value;
        }
    }

    [DisplayName("猜測次數")]
    public int GuessTimes
    {
        get
        {
            return _guessTimes;
        }
        set
        {
            _guessTimes = value;
        }
    }

    [DisplayName("正確率")]
    public int CorrectPercentage
    {
        get
        {
            return _correctPercentage;
        }
        set
        {
            _correctPercentage = value;
        }
    }

    [DisplayName("備註")]
    public String Comment
    {
        get
        {
            return _comment;
        }
        set
        {
            _comment = value;
        }
    }
}
