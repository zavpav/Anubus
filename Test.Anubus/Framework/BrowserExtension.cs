using OpenQA.Selenium;
using Protractor;

namespace TestConsoleTest;

/// <summary> Набор методов работы с selenium для gerkin тестов </summary>
public static class BrowserExtension
{
    /// <summary> Поиск кнопки по заголовку </summary>
    /// <param name="ngDriver">Драйвер</param>
    /// <param name="caption">Русское имя кнопки</param>
    /// <returns>Единственный элемент dx-button</returns>
    /// <exception cref="TestException">Ошибки поиска</exception>
    public static NgWebElement FindButtonByCaption(this NgWebDriver ngDriver, string caption)
    {
        var elements = ngDriver.FindElements(By.XPath($"//dx-button[@text='{caption}']"));
        if (elements.Count != 1)
        {
            if (elements.Count == 0)
            {
                var posibleErrElements = ngDriver.FindElements(By.XPath($"//dx-button[.//text()='{caption}']"));
                if (posibleErrElements.Count != 0)
                    Log.Default.Error("Ошибка поиска кнопки Похоже Кнопка сконфигурирована неверно (RusName '{RusName}')", caption);
            }

            Log.Default.Error("Ошибка поиска кнопки ({Count}) по RusName ({RusName})", elements.Count, caption);
            throw new TestException("Ошибка поиска элементов по RusName");
        }

        return elements[0];
    }

    /// <summary> Поиск единственного элемента по By для ввода данных (input) </summary>
    /// <param name="ngDriver">Драйвер</param>
    /// <param name="by">"Фильтр поиска"</param>
    /// <returns>Единственный элемент input</returns>
    /// <exception cref="TestException">Ошибки поиска</exception>
    /// <remarks>
    /// Ищем input по id или ещё как. Но id идёт к devextreme компонентам, которые как раз и содержат input для ввода.
    /// Поэтому ищем контейнер для input, а потом доискиваем уже input.
    /// </remarks>
    public static NgWebElement FindInputElementBy(this NgWebDriver ngDriver, By by)
    {
        System.Collections.ObjectModel.ReadOnlyCollection<NgWebElement> elements;
        try
        {
            elements = ngDriver.FindElements(by);
            if (elements.Count != 1)
            {
                Log.Default.Error("Ошибка поиска элементов ({Count}) по by {By}", elements.Count, by);
                throw new TestException("Ошибка поиска элементов по By");
            }
        }
        catch (Exception ex)
        {
            Log.Default.Error(ex, "Ошибка поиска элементов по by {By}", by);
            throw new TestException("Ошибка поиска элементов по By");
        }

        try
        {
            var inps = elements[0].FindElements(By.TagName("input"));
            if (inps.Count == 1)
                return inps[0]; // Если нашли один, то и хорошо.

            var subimps = inps.Where(x => x.GetAttribute("type") != "hidden").ToList();
            if (subimps.Count != 1)
            {
                Log.Default.Error("Ошибка поиска элементов input внутри блока по by {By} шаг 2", by);
                throw new TestException("Ошибка поиска элементов input внутри блока по By шаг 2");
            }
            return subimps[0];
        }
        catch (Exception ex)
        {
            Log.Default.Error(ex, "Ошибка поиска элементов input внутри блока по by {By}", by);
            throw new TestException("Ошибка поиска элементов input внутри блока по By");
        }
    }

    /// <summary> Поиск input по русскому наименованию поля </summary>
    /// <param name="ngDriver">Драйвер</param>
    /// <param name="caption">Русское имя поля</param>
    /// <returns>Единственный элемент input</returns>
    /// <exception cref="TestException">Ошибки поиска</exception>
    /// <remarks>
    /// Devextreme dxi-item у dx-form имеет примерно такую структуру:
    /// <![CDATA[
    ///             <div class="">
    ///                 <label class="" for="dx_dx-031fafca-f874-ad0a-0b76-0d0da5efd362_code">
    ///                     <span class="dx-field-item-label-content" style="width: 132px;">
    ///                         <span class="dx-field-item-label-text">#######Код:######</span>
    ///                     </span>
    ///                 </label>
    ///                 <div class="dx-field-item-content dx-field-item-content-location-right">
    ///                 <div class="dx-show-invalid-badge dx-textbox dx-texteditor dx-editor-outlined dx-texteditor-empty dx-widget">
    ///                     <div class="dx-texteditor-container">
    ///                         <div class="dx-texteditor-input-container">
    ///                             <input autocomplete = "off" id="dx_dx-031fafca-f874-ad0a-0b76-0d0da5efd362_code" class="dx-texteditor-input" type="text" >
    /// ]]>
    /// Т.е. для работы ищем span с именем (+двоеточие), потом поднимаемся до label с атрибутом for и потом ищем input с нужным id.
    /// </remarks>
    public static NgWebElement FindInputElementByCaption(this NgWebDriver ngDriver, string caption)
    {
        var possibleSpans = ngDriver.FindElements(By.XPath($"//span[text()='{caption}:']"));
        if (possibleSpans.Count != 1)
        {
            Log.Default.Error("Ошибка поиска элементов по русскому имени. Найдено ({Count}) по Заголовок '{RusName}'", possibleSpans.Count, caption);
            throw new TestException("Ошибка поиска элементов по Русскому имени поля");
        }

        var labelElement = possibleSpans[0].WrappedElement;
        var iteration = 6;
        var jsExecuter = (IJavaScriptExecutor)ngDriver.WrappedDriver;

        while (labelElement != null && iteration > 0 && string.IsNullOrEmpty(labelElement.GetDomAttribute("for")))
        {
            // Поиск родителя можно либо через xpath либо через js. На SO написали, что с js побыстрее.
            labelElement = (IWebElement)jsExecuter.ExecuteScript("return arguments[0].parentNode;", labelElement);
            iteration--;
        }
        if (labelElement == null)
        {
            Log.Default.Error("Ошибка поиска элементов по русскому имени. Не найден тег 'for' '{RusName}' currentElement == null", caption);
            throw new TestException("Ошибка поиска элементов по Русскому имени поля");
        }
        if (iteration == 0)
        {
            Log.Default.Error("Ошибка поиска элементов по русскому имени. Не найден тег 'for' '{RusName}' Превышено число итераций поиска тега 'for'", caption);
            throw new TestException("Ошибка поиска элементов по Русскому имени поля");
        }

        var labelId = labelElement.GetAttribute("for");
        var inputElements = ngDriver.FindElements(By.Id(labelId));
        if (inputElements.Count != 1)
        {
            Log.Default.Error("Ошибка поиска элементов по русскому имени. Найдено элементов {Count} для '{RusName}'", inputElements.Count, caption);
            throw new TestException("Ошибка поиска элементов по Русскому имени поля");
        }

        return inputElements[0];
    }
}
