﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Test.AnubusTest.Spr
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Ввод справочника РзПрз")]
    public partial class ВводСправочникаРзПрзFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("ru-RU"), "Spr", "Ввод справочника РзПрз", "Заполнение справочника РзПрз", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Первичная загрузка данных РзПрз")]
        [NUnit.Framework.CategoryAttribute("регрес")]
        public void ПервичнаяЗагрузкаДанныхРзПрз()
        {
            string[] tagsOfScenario = new string[] {
                    "регрес"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Первичная загрузка данных РзПрз", null, tagsOfScenario, argumentsOfScenario, featureTags);
            this.ScenarioInitialize(scenarioInfo);
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                testRunner.Given("в справочнике \'РзПрз\' количество записей = \'0\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Дано ");
                TechTalk.SpecFlow.Table table88 = new TechTalk.SpecFlow.Table(new string[] {
                            "Родитель",
                            "Код",
                            "Полное наименование",
                            "Краткое наименование",
                            "Начало",
                            "Конец"});
                table88.AddRow(new string[] {
                            "",
                            "0100",
                            "Общегосударственные вопросы",
                            "Общегосударственные вопросы",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0100",
                            "0101",
                            "Функционирование Президента Российской Федерации",
                            "Функционирование Президента Российской Федерации",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0100",
                            "0102",
                            "Функционирование высшего должностного лица субъекта Российской Федерации и муници" +
                                "пального образования",
                            "Функционирование высшего должностного лица субъекта Российской Федерации и муници" +
                                "пального образования",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0100",
                            "0103",
                            "Функционирование законодательных (представительных) органов государственной власт" +
                                "и и представительных органов муниципальных образований",
                            "Функционирование законодательных (представительных) органов государственной власт" +
                                "и и представительных органов муниципальных образований",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0100",
                            "0104",
                            "Функционирование Правительства Российской Федерации, высших исполнительных органо" +
                                "в государственной власти субъектов Российской Федерации, местных администраций",
                            "Функционирование Правительства Российской Федерации, высших исполнительных органо" +
                                "в государственной власти субъектов Российской Федерации, местных администраций",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0100",
                            "0105",
                            "Судебная система",
                            "Судебная система",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0100",
                            "0106",
                            "Обеспечение деятельности финансовых, налоговых и таможенных органов и органов фин" +
                                "ансового (финансово-бюджетного) надзора",
                            "Обеспечение деятельности финансовых, налоговых и таможенных органов и органов фин" +
                                "ансового (финансово-бюджетного) надзора",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0100",
                            "0107",
                            "Обеспечение проведения выборов и референдумов",
                            "Обеспечение проведения выборов и референдумов",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0100",
                            "0108",
                            "Международные отношения и международное сотрудничество",
                            "Международные отношения и международное сотрудничество",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0100",
                            "0109",
                            "Государственный материальный резерв",
                            "Государственный материальный резерв",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0100",
                            "0110",
                            "Фундаментальные исследования",
                            "Фундаментальные исследования",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0100",
                            "0111",
                            "Резервные фонды",
                            "Резервные фонды",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0100",
                            "0112",
                            "Прикладные научные исследования в области общегосударственных вопросов",
                            "Прикладные научные исследования в области общегосударственных вопросов",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0100",
                            "0113",
                            "Другие общегосударственные вопросы",
                            "Другие общегосударственные вопросы",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0100",
                            "0114",
                            "Прикладные научные исследования в области общегосударственных вопросов",
                            "Прикладные научные исследования в области общегосударственных вопросов",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0100",
                            "0115",
                            "Другие общегосударственные вопросы",
                            "Другие общегосударственные вопросы",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "",
                            "0200",
                            "Национальная оборона",
                            "Национальная оборона",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0200",
                            "0201",
                            "Вооруженные Силы Российской Федерации",
                            "Вооруженные Силы Российской Федерации",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0200",
                            "0202",
                            "Мобилизационная и вневойсковая подготовка",
                            "Мобилизационная и вневойсковая подготовка",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0200",
                            "0203",
                            "Мобилизационная и вневойсковая подготовка",
                            "Мобилизационная и вневойсковая подготовка",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0200",
                            "0204",
                            "Мобилизационная подготовка экономики",
                            "Мобилизационная подготовка экономики",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0200",
                            "0205",
                            "Подготовка и участие в обеспечении коллективной безопасности и миротворческой дея" +
                                "тельности",
                            "Подготовка и участие в обеспечении коллективной безопасности и миротворческой дея" +
                                "тельности",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0200",
                            "0206",
                            "Ядерно-оружейный комплекс",
                            "Ядерно-оружейный комплекс",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0200",
                            "0207",
                            "Реализация международных обязательств в сфере военно-технического сотрудничества",
                            "Реализация международных обязательств в сфере военно-технического сотрудничества",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0200",
                            "0208",
                            "Прикладные научные исследования в области национальной обороны",
                            "Прикладные научные исследования в области национальной обороны",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "",
                            "0300",
                            "Национальная безопасность и правоохранительная деятельность",
                            "Национальная безопасность и правоохранительная деятельность",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0300",
                            "0301",
                            "Органы прокуратуры и следствия",
                            "Органы прокуратуры и следствия",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0300",
                            "0302",
                            "Органы внутренних дел",
                            "Органы внутренних дел",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0300",
                            "0303",
                            "Внутренние войска",
                            "Внутренние войска",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0300",
                            "0304",
                            "Органы юстиции",
                            "Органы юстиции",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0300",
                            "0305",
                            "Система исполнения наказаний",
                            "Система исполнения наказаний",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0300",
                            "0306",
                            "Органы безопасности",
                            "Органы безопасности",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0300",
                            "0307",
                            "Органы пограничной службы",
                            "Органы пограничной службы",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0300",
                            "0308",
                            "Органы по контролю за оборотом наркотических средств и психотропных веществ",
                            "Органы по контролю за оборотом наркотических средств и психотропных веществ",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0300",
                            "0309",
                            "Защита населения и территории от чрезвычайных ситуаций природного и техногенного " +
                                "характера, гражданская оборона",
                            "Защита населения и территории от чрезвычайных ситуаций природного и техногенного " +
                                "характера, гражданская оборона",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0300",
                            "0310",
                            "Обеспечение пожарной безопасности",
                            "Обеспечение пожарной безопасности",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0300",
                            "0311",
                            "Миграционная политика",
                            "Миграционная политика",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0300",
                            "0312",
                            "Прикладные научные исследования в области национальной безопасности и правоохрани" +
                                "т",
                            "Прикладные научные исследования в области национальной безопасности и правоохрани" +
                                "т",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0300",
                            "0313",
                            "Прикладные научные исследования в области национальной безопасности и правоохрани" +
                                "тельной деятельности",
                            "Прикладные научные исследования в области национальной безопасности и правоохрани" +
                                "тельной деятельности",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "",
                            "0400",
                            "Национальная экономика",
                            "Национальная экономика",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0400",
                            "0401",
                            "Общеэкономические вопросы",
                            "Общеэкономические вопросы",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0400",
                            "0402",
                            "Топливно-энергетический комплекс",
                            "Топливно-энергетический комплекс",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0400",
                            "0403",
                            "Исследование и использование космического пространства",
                            "Исследование и использование космического пространства",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0400",
                            "0404",
                            "Воспроизводство минерально-сырьевой базы",
                            "Воспроизводство минерально-сырьевой базы",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0400",
                            "0405",
                            "Сельское хозяйство и рыболовство",
                            "Сельское хозяйство и рыболовство",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0400",
                            "0406",
                            "Водное хозяйство",
                            "Водное хозяйство",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0400",
                            "0407",
                            "Лесное хозяйство",
                            "Лесное хозяйство",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0400",
                            "0408",
                            "Транспорт",
                            "Транспорт",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0400",
                            "0409",
                            "Дорожное хозяйство (дорожные фонды)",
                            "Дорожное хозяйство (дорожные фонды)",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0400",
                            "0410",
                            "Связь и информатика",
                            "Связь и информатика",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0400",
                            "0411",
                            "Прикладные научные исследования в области национальной экономики",
                            "Прикладные научные исследования в области национальной экономики",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "",
                            "0500",
                            "Жилищно-коммунальное хозяйство",
                            "Жилищно-коммунальное хозяйство",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0500",
                            "0501",
                            "Жилищное хозяйство",
                            "Жилищное хозяйство",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0500",
                            "0502",
                            "Коммунальное хозяйство",
                            "Коммунальное хозяйство",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0500",
                            "0503",
                            "Благоустройство",
                            "Благоустройство",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0500",
                            "0504",
                            "Прикладные научные исследования в области жилищно-коммунального хозяйства",
                            "Прикладные научные исследования в области жилищно-коммунального хозяйства",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "",
                            "0600",
                            "Охрана окружающей среды",
                            "Охрана окружающей среды",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0600",
                            "0601",
                            "Экологический контроль",
                            "Экологический контроль",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0600",
                            "0602",
                            "Сбор, удаление отходов и очистка сточных вод",
                            "Сбор, удаление отходов и очистка сточных вод",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0600",
                            "0603",
                            "Охрана объектов растительного и животного мира и среды их обитания",
                            "Охрана объектов растительного и животного мира и среды их обитания",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0600",
                            "0604",
                            "Прикладные научные исследования в области охраны окружающей среды",
                            "Прикладные научные исследования в области охраны окружающей среды",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "",
                            "0700",
                            "Образование",
                            "Образование",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0700",
                            "0701",
                            "Дошкольное образование",
                            "Дошкольное образование",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0700",
                            "0702",
                            "Общее образование",
                            "Общее образование",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0700",
                            "0703",
                            "Начальное профессиональное образование",
                            "Начальное профессиональное образование",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0700",
                            "0704",
                            "Среднее профессиональное образование",
                            "Среднее профессиональное образование",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0700",
                            "0705",
                            "Профессиональная подготовка, переподготовка и повышение квалификации",
                            "Профессиональная подготовка, переподготовка и повышение квалификации",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0700",
                            "0706",
                            "Высшее и послевузовское профессиональное образование",
                            "Высшее и послевузовское профессиональное образование",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0700",
                            "0707",
                            "Молодежная политика и оздоровление детей",
                            "Молодежная политика и оздоровление детей",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0700",
                            "0708",
                            "Прикладные научные исследования в области образования",
                            "Прикладные научные исследования в области образования",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0700",
                            "0709",
                            "Другие вопросы в области образования",
                            "Другие вопросы в области образования",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "",
                            "0800",
                            "КУЛЬТУРА, КИНЕМАТОГРАФИЯ",
                            "КУЛЬТУРА, КИНЕМАТОГРАФИЯ",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0800",
                            "0801",
                            "Культура, кинематография",
                            "Культура, кинематография",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0800",
                            "0802",
                            "Кинематография",
                            "Кинематография",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0800",
                            "0803",
                            "Прикладные научные исследования в области культуры, кинематографии",
                            "Прикладные научные исследования в области культуры, кинематографии",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0800",
                            "0804",
                            "Другие вопросы в области культуры, кинематографии",
                            "Другие вопросы в области культуры, кинематографии",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0800",
                            "0805",
                            "Прикладные научные исследования в области культуры, кинематографии и средств масс" +
                                "о",
                            "Прикладные научные исследования в области культуры, кинематографии и средств масс" +
                                "о",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0800",
                            "0806",
                            "Другие вопросы в области культуры, кинематографии и средств массовой информации",
                            "Другие вопросы в области культуры, кинематографии и средств массовой информации",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "",
                            "0900",
                            "Здравоохранение",
                            "Здравоохранение",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0900",
                            "0901",
                            "Стационарная медицинская помощь",
                            "Стационарная медицинская помощь",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0900",
                            "0902",
                            "Амбулаторная помощь",
                            "Амбулаторная помощь",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0900",
                            "0903",
                            "Медицинская помощь в дневных стационарах всех типов",
                            "Медицинская помощь в дневных стационарах всех типов",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0900",
                            "0904",
                            "Скорая медицинская помощь",
                            "Скорая медицинская помощь",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0900",
                            "0905",
                            "Санаторно-оздоровительная помощь",
                            "Санаторно-оздоровительная помощь",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "0900",
                            "0907",
                            "Санитарно-эпидемиологическое благополучие",
                            "Санитарно-эпидемиологическое благополучие",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "",
                            "1000",
                            "Социальная политика",
                            "Социальная политика",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "1000",
                            "1001",
                            "Пенсионное обеспечение",
                            "Пенсионное обеспечение",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "1000",
                            "1002",
                            "Социальное обслуживание населения",
                            "Социальное обслуживание населения",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "1000",
                            "1003",
                            "Социальное обеспечение населения",
                            "Социальное обеспечение населения",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "1000",
                            "1004",
                            "Охрана семьи и детства",
                            "Охрана семьи и детства",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "1000",
                            "1005",
                            "Прикладные научные исследования в области социальной политики",
                            "Прикладные научные исследования в области социальной политики",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "1000",
                            "1006",
                            "Другие вопросы в области социальной политики",
                            "Другие вопросы в области социальной политики",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "",
                            "1100",
                            "Физическая культура и спорт",
                            "Физическая культура и спорт",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "1100",
                            "1101",
                            "Физическая культура",
                            "Физическая культура",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "1100",
                            "1102",
                            "Массовый спорт",
                            "Массовый спорт",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "1100",
                            "1103",
                            "Спорт высших достижений",
                            "Спорт высших достижений",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "1100",
                            "1104",
                            "Прикладные научные исследования в области физической культуры и спорта",
                            "Прикладные научные исследования в области физической культуры и спорта",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "",
                            "1200",
                            "Средства массовой информации",
                            "Средства массовой информации",
                            "01.01.1900",
                            "01.01.2100"});
                table88.AddRow(new string[] {
                            "1200",
                            "1202",
                            "Периодическая печать и издательства",
                            "Периодическая печать и издательства",
                            "01.01.1900",
                            "01.01.2100"});
                testRunner.When("вводим в справочник \'РзПрз\' записи:", ((string)(null)), table88, "Когда ");
                testRunner.Then("в справочнике \'РзПрз\' количество записей = \'99\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Тогда ");
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
