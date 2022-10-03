namespace TestConsoleTest.Framework;


[Binding]
public class SprLoadStepDefinition
{
    [StepDefinition(@"в форме редактирования организации ввести счет")]
    public void ВФормеРедактированияОрагинзацииВвестиСчет(Table table)
    {
        Log.Default.Warning("Заблокирован степ 'в форме редактирования организации ввести счет'");

        //foreach (var row in table.Rows)
        //{
        //    DocStepDefinition.FindAndPressButton("Добавить");

        //    var form = TestHelper.GetActiveForm();
        //    var gridControl = (DevExpress.XtraGrid.GridControl)((Control)form.Control).Controls.OfType<Control>().ExtractTree(x => x.Controls.OfType<Control>()).Single(x => x is DevExpress.XtraGrid.GridControl);
        //    var gridView = gridControl.DefaultView;
        //    var dataS = (IList<Sphaera.Bp.Visual.Common.Spr.Organization.PresentorSprOrgAccount>)gridView.DataSource;
        //    var presentorAccount = dataS.Single(x => string.IsNullOrWhiteSpace(x.Account));
        //    presentorAccount.AccountType = row["Тип лицевого счета"];
        //    presentorAccount.Account = row["Номер лицевого счета"];
        //    presentorAccount.TofkSid = Locator.Resolve<ISprTofkRepository>().Cache.IsActual(Locator.Resolve<IMainContext>().Glodate).Single(x => x.Code == row["ТОФК"]).Sid;
        //    if (row.ContainsKey("По умолчанию"))
        //    {
        //        if (row["По умолчанию"].ToLower() == "да")
        //            presentorAccount.IsDefault = true;
        //        else if (row["По умолчанию"].ToLower() == "нет")
        //            presentorAccount.IsDefault = false;
        //        else
        //            throw new NotSupportedException("Не определен параметр 'По умолчанию' " + row["По умолчанию"]);
        //    }

        //    gridView.RefreshData();
        //}
    }

    [StepDefinition(@"в форме редактирования организации ввести регион")]
    public void ВФормеРедактированияОрагинзацииВвестиРегион(Table table)
    {
        Log.Default.Warning("Заблокирован степ 'в форме редактирования организации ввести регион'");
        //var row = table.Rows.Single();

        //var  form = TestHelper.GetActiveForm();
        //var gridControl = (DevExpress.XtraGrid.GridControl)((Control)form.Control).Controls.OfType<Control>().ExtractTree(x => x.Controls.OfType<Control>()).Single(x => x is DevExpress.XtraGrid.GridControl);
        //var gridView = gridControl.DefaultView;
        //var dataS = (IList<Sphaera.Bp.Visual.Common.Spr.Organization.PresentorSprOrgAccount>)gridView.DataSource;
        //var presentorAccount = dataS[0];
        //presentorAccount.AccountType = row["Тип лицевого счета"];
        //presentorAccount.Account = row["Номер лицевого счета"];
        //presentorAccount.TofkSid = Locator.Resolve<ISprTofkRepository>().Cache.IsActual(Locator.Resolve<IMainContext>().Glodate).Single(x => x.Code == row["ТОФК"]).Sid;
        //gridView.RefreshData();
    }

    [StepDefinition("есть данные в справочнике '([^']+)'")]
    public void ExistDataInSprGiven(string sprName)
    {
        Log.Default.Warning("Заблокирован степ 'есть данные в справочнике '([^']+)''");

        //var repository = TestDomainInform.GetRepository<ISprRepository>(sprName);
        //if (!repository.ActualRowList.Any())
        //    throw new IgnoreException("Нет данных в справочнике: " + sprName);
    }

    [StepDefinition("вводим в справочник '([^']+)' запись:")]
    [StepDefinition("вводим в справочник '([^']+)' записи:")]
    public void InsertSprRows(string sprName, Table rows)
    {
        Log.Default.Warning("Заблокирован степ 'вводим в справочник '([^']+)' запись:'");

        //sprName = TestHelper.ReplaceVariable(sprName);
        //rows = TestHelper.ReplaceVariable(rows);

        //var repository = this.TestDomainInform.GetRepository<ISprRepository>(sprName);
        //var newDomainFactory = this.TestDomainInform.GetDomainNewFactory<ISprBase>(sprName);

        //foreach (var row in rows.Rows)
        //{
        //    try
        //    {
        //        var domain = TestHelper.FillSprDomain(this.TestDomainInform, sprName, newDomainFactory, row, repository);
        //        repository.UntypedSave(domain);
        //    }
        //    catch (Exception ex)
        //    {
        //        LoggerS.ErrorMessage(ex, "Ошибка загрузки справочника {Строка}", row.ToDictionary(x => x.Key, x => x.Value));
        //        throw;
        //    }
        //}
    }

    /// <summary>
    /// Степ вводит данные в справочник, если нет актуальной записи на "текущий момент".
    /// Проверка наличия данных идёт по columnFindCheck. Если не находит - вколачивает данные.
    /// Если находит проверяет на совпадение все колонки кроме uncheckedColumns которые записаны через разделитель |.
    /// Если запись есть и не совпадает - крешимся.
    /// 
    /// Если первая по порядку колонка - это колонка "Родитель", проверяется, что код из columnFindCheck является потомком кода из этой колонки.
    /// В противном случае данная проверка не производится.
    /// </summary>
    /// <param name="sprName"></param>
    /// <param name="columnFindCheck"></param>
    /// <param name="uncheckedColumns"></param>
    /// <param name="rows"></param>
    [StepDefinition(@"вводим в справочник '([^']+)' запись с проверкой по '([^']+)' без проверок колонок '([^']+)':")]
    [StepDefinition(@"вводим в справочник '([^']+)' записи с проверкой по '([^']+)' без проверок колонок '([^']+)':")]
    public void InsertSprRowsWithCheck(string sprName, string columnFindCheck, string uncheckedColumns, Table rows)
    {
        Log.Default.Warning("Заблокирован степ 'вводим в справочник '([^']+)' запись с проверкой по '([^']+)' без проверок колонок '([^']+)':'");

        //sprName = TestHelper.ReplaceVariable(sprName);
        //columnFindCheck = TestHelper.ReplaceVariable(columnFindCheck);
        //uncheckedColumns = TestHelper.ReplaceVariable(uncheckedColumns);
        //rows = TestHelper.ReplaceVariable(rows);

        //var needCodeCheck = rows.Header.First() == "Родитель";

        //var logger = LoggerS.GetLogProxy("specflow");
        //logger.Info("Загрузка справочника {Справочник} c проверкой поля {Поле} и игнорированием полей при проверке {Игнорирование}", sprName, columnFindCheck, uncheckedColumns);

        //var allProperties = this.TestDomainInform.GetAllProperties(sprName);

        //foreach (var colName in rows.Header)
        //{
        //    if (allProperties.All(x => x.Name != colName && x.PropertyInfo.Name != colName))
        //        throw new NotSupportedException("В справочнике " + sprName + " не найдено поле для колонки " + colName);
        //}
        //if (allProperties.All(x => x.Name != columnFindCheck))
        //    throw new NotSupportedException("В справочнике " + sprName + " не найдено поле для колонки " + columnFindCheck);

        //var findProp = allProperties.Single(x => x.Name == columnFindCheck);
        //var ignoreCheck = uncheckedColumns.Split('|');
        //var checkProps = rows.Header.Where(x => ignoreCheck.All(xx => xx != x)).ToList();
        //var checkDomainProps = allProperties.Where(x => checkProps.Contains(x.Name)).ToDictionary(x => x.Name, x => x);
        //if (checkDomainProps.Count != checkProps.Count)
        //    throw new NotSupportedException("Нашли не все свойства для проверок");

        //var internalDbContext = Locator.Resolve<IInternalDbContextValidate>();
        //var repository = this.TestDomainInform.GetRepository<ISprRepository>(sprName);
        //var newDomainFactory = this.TestDomainInform.GetDomainNewFactory<ISprBase>(sprName);
        //var actualRows = repository.ActualRowList.ToList();
        //var suppressExtrimeCheck = internalDbContext.SuppressExtrimeCheck;
        //internalDbContext.SuppressExtrimeCheck = true;
        //internalDbContext.BeginTransaction();
        //try
        //{
        //    var isOk = true;
        //    foreach (var row in rows.Rows)
        //    {
        //        try
        //        {
        //            var findVal = row[columnFindCheck];

        //            if (needCodeCheck)
        //            {
        //                var template = row[0].TrimEnd(new char[] { '0' });
        //                if (!findVal.StartsWith(template))
        //                    throw new NotSupportedException(string.Format(
        //                                "Ошибка при записи в справочник {0}. Код {1} не является потомком родительского кода {2}",
        //                                sprName, findVal, row[0]));
        //            }

        //            var alreadeCreatedRows = actualRows.Where(x => findVal.Equals(findProp.Getter(x))).ToList();
        //            if (alreadeCreatedRows.Count > 1)
        //                throw new NotSupportedException(string.Format("В справочнике {0} найдено слишком много активных строк по фильтру {1}={2} найдено строк {3}",
        //                                                sprName, columnFindCheck, findVal, alreadeCreatedRows.Count));

        //            if (alreadeCreatedRows.Count == 0)
        //            {
        //                var domain = TestHelper.FillSprDomain(this.TestDomainInform, sprName, newDomainFactory, row, repository);
        //                repository.UntypedSave(domain);
        //            }
        //            else
        //            {
        //                var existDomain = alreadeCreatedRows[0];
        //                foreach (var checkProp in checkProps)
        //                {
        //                    var currVal = checkDomainProps[checkProp].Getter(existDomain);
        //                    var checkVal = TestHelper.ParseStringValue(checkDomainProps[checkProp].PropertyInfo, row[checkProp]);
        //                    if (!checkVal.Equals(currVal))
        //                    {
        //                        isOk = false;
        //                        logger.Error("В словаре {Словарь} данные в колонке {Колонка} по фильтру {Поиск}={Значение} не совпадают {СтароеЗначение}!={НовоеЗначение}",
        //                                        sprName, checkProp, columnFindCheck, findVal, currVal, checkVal);
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            LoggerS.ErrorMessage(ex, "Ошибка загрузки справочника {Строка}", row.ToDictionary(x => x.Key, x => x.Value));
        //            throw;
        //        }
        //    }

        //    if (!isOk)
        //        throw new NotSupportedException("Ошибка загрузки-проверки справочника " + sprName);


        //    internalDbContext.CommitTransaction();
        //}
        //catch (Exception)
        //{
        //    internalDbContext.RollbackTransaction();
        //    throw;
        //}
        //finally
        //{
        //    internalDbContext.SuppressExtrimeCheck = suppressExtrimeCheck;
        //}

    }

    [StepDefinition(@"закрыть активные записи справочника '([^']+)' датой '([^']+)'")]
    public void ЗакрытьАктивныеЗаписиСправочникаДатой(string sprName, string dt)
    {
        Log.Default.Warning("Заблокирован степ 'закрыть активные записи справочника '([^']+)' датой '([^']+)''");

        //sprName = TestHelper.ReplaceVariable(sprName);
        //dt = TestHelper.ReplaceVariable(dt);

        //var repository = this.TestDomainInform.GetRepository<ISprRepository>(sprName);
        //var allProperties = this.TestDomainInform.GetAllProperties(sprName);
        //var toDateProp = allProperties.Single(x => x.PropertyInfo.Name == "ToDate");

        //var lastDt = new DateTime(2100, 1, 1);
        //var openSprRows = repository.AllCacheRows.Where(x => (DateTime)toDateProp.Getter(x) == lastDt).ToList();

        //foreach (var sprRow in openSprRows)
        //{
        //    var fullRow = repository.UnTypedGet(sprRow.Sid);
        //    toDateProp.Setter(fullRow, dt);
        //    repository.SaveWithoutRefresh((ISprBase)fullRow);
        //}
        //repository.DomainRepositoryRefreshCache();
    }

    [StepDefinition(@"вводим в справочник Организации записи:")]
    public void CreateOrganizations(Table table)
    {
        Log.Default.Warning("Заблокирован степ 'вводим в справочник Организации записи:'");

        //foreach (var orgCol in new[]
        //{
        //        "Номер", "Группа", "Код", "Тип организации", "Начало", "Конец", "Родитель",
        //        "Сокращенное наименование", "Полное наименование", "Краткое наименование",
        //        "[ЛС]ТОФК:Код -> ТОФК", "[ЛС]Тип Лицевого счета", "[ЛС]Номер Лицевого счета"
        //    }
        //.Where(orgCol => !table.ContainsColumn(orgCol)))
        //{
        //    throw new IgnoreException("В конфигурации нет поля " + orgCol);
        //}

        //var dbRepository = (IDbSprOrganizationTest)Locator.Resolve<IDbSprOrganization>();
        //dbRepository.DisableResortTrigger();

        //foreach (var row in table.Rows)
        //{
        //    this.SaveSingleOrganization(row);
        //}

        //dbRepository.EnableResortTrigger();
    }

    [StepDefinition("в справочнике '([^']+)' есть запись с '([^']+)'='([^']+)'")]
    public void CheckSprRow(string sprName, string rusFieldName, string fieldValue)
    {
        Log.Default.Warning("Заблокирован степ 'в справочнике '([^']+)' есть запись с '([^']+)'='([^']+)''");

        //var repository = TestDomainInform.GetRepository<IDomainRepository>(sprName);
        //var pi = TestDomainInform.GetPropertyInfo(sprName, rusFieldName);
        //if (!repository.UnTypedCache().Any(x => pi.GetValue(x, new object[] { }).Equals(fieldValue)))
        //    throw new AssertionException(string.Format("Нет данных '{0}'='{1} в справочнике '{2}'({3})", rusFieldName, fieldValue, sprName, repository.GetType().Name));
    }

    [StepDefinition("в справочнике '([^']+)' количество записей = '([^']+)'")]
    public void GivenSprRowCount(string sprName, int rowCount)
    {
        Log.Default.Warning("Заблокирован степ 'в справочнике '([^']+)' количество записей = '([^']+)''");

        //var repository = this.TestDomainInform.GetRepository<IDomainRepository>(sprName);
        //var repositoryCnt = repository.UnTypedCache().Count();
        //if (repositoryCnt != rowCount)
        //    SpecFlowHelper.ThrowException(true, "Количество записей в справочнике {0} не совпадает с ожидаемым {1} != {2}", sprName, repositoryCnt, rowCount);
    }

    [StepDefinition("файл '([^']+)' еще не загружен")]
    public void GivenLoadedFilesCount(string fileName)
    {
        Log.Default.Warning("Заблокирован степ 'файл '([^']+)' еще не загружен'");

        //var repository = TestDomainInform.GetRepository<IDomainRepository>("Загрузка файлов ОФК");
        //var filesCount = ((Sphaera.Bp.Bl.Loader.Ofk.IOfkFilesRepository)repository).Cache.Count(x => new FileInfo(x.FileName).Name == fileName);
        //if (filesCount != 0)
        //    SpecFlowHelper.ThrowException(true, "Файл с именем {0} уже загружен", fileName);
    }

    [StepDefinition("привязать существующие ПБС к кодам ОКС 2021")]
    public void LinkSprFaipToOrganizations()
    {
        Log.Default.Warning("Заблокирован степ 'привязать существующие ПБС к кодам ОКС 2021'");

        //var faipRepository = TestDomainInform.GetRepository<IDomainRepository>("Справочник кодов ОКС");
        //var orgRepository = TestDomainInform.GetRepository<IDomainRepository>("Организации");
        //var faipToPbsRepository = TestDomainInform.GetRepository<ISprRepository>("Привязка кодов ОКС к ПБС");
        //var sidGenerator = Locator.Resolve<ITemporarySidGenerator>();

        //foreach (var faip in faipRepository.UnTypedCache())
        //{
        //    foreach (var org in orgRepository.UnTypedCache())
        //    {
        //        var pbs = ((SprOrganization)org);
        //        if (pbs.OrgType != EnumOrgType.Rbs)
        //            continue;

        //        var domain = new SprFaipToPbs();
        //        domain.Sid = sidGenerator.NextTempSid();
        //        domain.FaipSid = ((SprFaip)faip).Sid;
        //        domain.PbsSid = pbs.Sid;
        //        domain.OnDate = ((SprFaip)faip).OnDate >= pbs.OnDate ? ((SprFaip)faip).OnDate : pbs.OnDate;
        //        domain.ToDate = ((SprFaip)faip).ToDate <= pbs.OnDate ? ((SprFaip)faip).ToDate : pbs.ToDate;

        //        faipToPbsRepository.UntypedSave(domain);
        //    }
        //}
    }

    [StepDefinition(@"заполнить параметры формы")]
    public void ЗаполнитьПараметрыФормы(Table table)
    {
        Log.Default.Warning("Заблокирован степ 'заполнить параметры формы'");
        
        table = Locator.Resolve<ITestExternalStepParameters>().ReplaceParameters(table);

        if (!table.ContainsColumn("Поле"))
            throw new IgnoreException("Не найдено поле 'Поле'");
        if (!table.ContainsColumn("Значение"))
            throw new IgnoreException("Не найдено поле 'Значение'");

        //foreach (var row in table.Rows)
        //{
        //    var fieldName = row["Поле"];
        //    var stringValue = row["Значение"];
        //    Control editor = null;

        //    if (fieldName.Contains("->"))
        //    {
        //        this.FillLookup(fieldName, stringValue);
        //    }
        //    else
        //    {
        //        try
        //        {
        //            editor = TestHelper.FindControlOnActiveForm(fieldName);
        //            if (editor is DevExpress.XtraEditors.DateEdit)
        //                ((DevExpress.XtraEditors.DateEdit)editor).DateTime = DateTime.Parse(stringValue);
        //            else if (editor is DevExpress.XtraEditors.LookUpEdit)
        //                this.FillLookup(fieldName, stringValue);
        //            else if (editor is DevExpress.XtraEditors.TextEdit)
        //                ((DevExpress.XtraEditors.TextEdit)editor).Text = stringValue;
        //            else if (editor is DevExpress.XtraEditors.CheckEdit)
        //            {
        //                bool val;
        //                var strValue = stringValue.ToLower();
        //                switch (strValue)
        //                {
        //                    case "да":
        //                    case "true":
        //                        val = true;
        //                        break;
        //                    case "нет":
        //                    case "false":
        //                        val = false;
        //                        break;
        //                    default:
        //                        throw new ConversionNotSupportedException(string.Format("Не получилось преобразовать {0} в тип bool", stringValue));
        //                }
        //                ((DevExpress.XtraEditors.CheckEdit)editor).Checked = val;
        //            }
        //            else if (editor is DevExpress.XtraEditors.RadioGroup)
        //            {
        //                foreach (DevExpress.XtraEditors.Controls.RadioGroupItem itm in ((DevExpress.XtraEditors.RadioGroup)editor).Properties.Items)
        //                {
        //                    if (itm.Description.ToLower() == stringValue.ToLower())
        //                    {
        //                        ((DevExpress.XtraEditors.RadioGroup)editor).EditValue = itm.Value;
        //                        break;
        //                    }
        //                }

        //            }
        //            else
        //            {
        //                throw new NotSupportedException("не поддерживается контрол типа " + editor.GetType().FullName);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            log4net.LogManager.GetLogger("SpecFlow").ErrorFormat("Ошибка задания поля {0} {1} Редактор: {2}\n{3}", fieldName, stringValue, editor == null ? "Не найден" : editor.GetType().FullName, ex);
        //            throw;
        //        }
        //    }
        //}
    }

    [StepDefinition(@"в контроле '([^']+)' нажать кнопку '([^']+)'")]
    public void ЕслиВКонтролеНажатьКнопку(string ctlName, string buttonName)
    {
        Log.Default.Warning("Заблокирован степ 'в контроле '([^']+)' нажать кнопку '([^']+)''");

        //ctlName = Locator.Resolve<ITestExternalStepParameters>().ReplaceParameters(ctlName);
        //buttonName = Locator.Resolve<ITestExternalStepParameters>().ReplaceParameters(buttonName);

        //var editor = TestHelper.FindControlOnActiveForm(ctlName) as ButtonEdit;
        //if (editor == null)
        //    throw new TestException("Не найден контрол " + ctlName + " или не является ButtonEdit");

        //EditorButton fndBtn;
        //if (buttonName.StartsWith("#"))
        //{
        //    var idx = 0;
        //    try
        //    {
        //        idx = Int32.Parse(buttonName.Replace("#", ""));
        //    }
        //    catch
        //    {
        //        throw new TestException("Не смогли найти индекс кнопки " + buttonName);
        //    }

        //    try
        //    {
        //        fndBtn = editor.Properties.Buttons[idx - 1];
        //    }
        //    catch
        //    {
        //        throw new TestException("Не смогли получить кнопку по индексу (индекс должен быть с единицы) " + buttonName);
        //    }
        //}
        //else
        //{
        //    throw new IgnoreException("Лень, пока не доделал поиск кнопки по имени");
        //}

        //editor.PerformClick(fndBtn);
    }
}
