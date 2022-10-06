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
    [NUnit.Framework.DescriptionAttribute("Ввод справочника КОСГУ")]
    public partial class ВводСправочникаКОСГУFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("ru-RU"), "Spr", "Ввод справочника КОСГУ", "Заполнение справочники КОСГУ", ProgrammingLanguage.CSharp, featureTags);
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
        [NUnit.Framework.DescriptionAttribute("Первичная загрузка данных КОСГУ")]
        [NUnit.Framework.CategoryAttribute("регрес")]
        public void ПервичнаяЗагрузкаДанныхКОСГУ()
        {
            string[] tagsOfScenario = new string[] {
                    "регрес"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Первичная загрузка данных КОСГУ", null, tagsOfScenario, argumentsOfScenario, featureTags);
            this.ScenarioInitialize(scenarioInfo);
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                testRunner.Given("в справочнике \'КОСГУ\' количество записей = \'0\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Дано ");
                TechTalk.SpecFlow.Table table91 = new TechTalk.SpecFlow.Table(new string[] {
                            "Родитель",
                            "Код",
                            "Полное наименование",
                            "Краткое наименование",
                            "Начало",
                            "Конец"});
                table91.AddRow(new string[] {
                            "",
                            "200",
                            "Расходы",
                            "Расходы",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "200",
                            "210",
                            "Оплата труда и начисления на выплаты по оплате труда",
                            "Оплата труда и начисления на выплаты по оплате труда",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "210",
                            "211",
                            "Заработная плата",
                            "Заработная плата",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "210",
                            "212",
                            "Прочие выплаты",
                            "Прочие выплаты",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "210",
                            "213",
                            "Начисления на выплаты по оплате труда",
                            "Начисления на выплаты по оплате труда",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "200",
                            "220",
                            "Оплата работ, услуг",
                            "Оплата работ, услуг",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "220",
                            "221",
                            "Услуги связи",
                            "Услуги связи",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "220",
                            "222",
                            "Транспортные услуги",
                            "Транспортные услуги",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "220",
                            "223",
                            "Коммунальные услуги",
                            "Коммунальные услуги",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "220",
                            "224",
                            "Арендная плата за пользование имуществом",
                            "Арендная плата за пользование имуществом",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "220",
                            "225",
                            "Работы, услуги по содержанию имущества",
                            "Работы, услуги по содержанию имущества",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "220",
                            "226",
                            "Прочие работы, услуги",
                            "Прочие работы, услуги",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "200",
                            "260",
                            "Социальное обеспечение",
                            "Социальное обеспечение",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "260",
                            "262",
                            "Пособия по социальной помощи населению",
                            "Пособия по социальной помощи населению",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "260",
                            "263",
                            "Пенсии, пособия, выплачиваемые организациями сектора государственного управления",
                            "Пенсии, пособия, выплачиваемые организациями сектора государственного управления",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "200",
                            "290",
                            "Прочие расходы",
                            "Прочие расходы",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "",
                            "300",
                            "Поступление нефинансовых активов",
                            "Поступление нефинансовых активов",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "300",
                            "310",
                            "Увеличение стоимости основных средств",
                            "Увеличение стоимости основных средств",
                            "01.01.1900",
                            "01.01.2100"});
                table91.AddRow(new string[] {
                            "300",
                            "340",
                            "Увеличение стоимости материальных запасов",
                            "Увеличение стоимости материальных запасов",
                            "01.01.1900",
                            "01.01.2100"});
                testRunner.When("вводим в справочник \'КОСГУ\' записи:", ((string)(null)), table91, "Когда ");
                testRunner.Then("в справочнике \'КОСГУ\' количество записей = \'19\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Тогда ");
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
