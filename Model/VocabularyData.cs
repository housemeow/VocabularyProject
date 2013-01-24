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

    [DisplayName("�s��")]
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

    [DisplayName("��r")]
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

    [DisplayName("�[�J�ɶ�")]
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

    [DisplayName("�������")]
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

    [DisplayName("�^�����")]
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

    [DisplayName("�ҥy")]
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

    [DisplayName("�ҥy�������")]
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

    [DisplayName("���隸��")]
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

    [DisplayName("�q������")]
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

    [DisplayName("���T�v")]
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

    [DisplayName("�Ƶ�")]
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
