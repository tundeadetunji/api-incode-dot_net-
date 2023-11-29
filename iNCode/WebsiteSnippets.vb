'from iNovation
Imports iNovation.Code.General
Imports iNovation.Code.Desktop
Imports System.Web.Profile
Public Class WebsiteSnippets
#Region "Members"

	Enum DashboardComponents
		DashboardECommerce = 0
	End Enum


	Public Property DashboardComponents_List As List(Of String) = GetEnum(New DashboardComponents)
#End Region

#Region "Support Functions"

#End Region

#Region "Main"
	Public Function DashboardECommercePageLoad() As String
		Return "#Region ""Shared""
		ChartsDrop({dropChartCostVsGain, dropChartInvoiceCount, dropChartQuantitySold, dropChartCustomersCount}, ChartPattern.Bar)
		ChartsDrop({dropChartQuantityPerCategory}, ChartPattern.PieDoughnut)
#End Region

#Region ""Sales - Cost vs Gain""

		Dim cost_minus_two_query As String = BuildSumString_UNGROUPED(""Sales"", ""TotalCost"", {""RecordDate""})
		Dim cost_minus_two_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, -2, Now))}
		Dim cost_minus_two = QData(cost_minus_two_query, con_string, cost_minus_two_query_kv)

		Dim cost_minus_one_query As String = BuildSumString_UNGROUPED(""Sales"", ""TotalCost"", {""RecordDate""})
		Dim cost_minus_one_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, -1, Now))}
		Dim cost_minus_one = QData(cost_minus_one_query, con_string, cost_minus_one_query_kv)

		Dim cost_minus_zero_query As String = BuildSumString_UNGROUPED(""Sales"", ""TotalCost"", {""RecordDate""})
		Dim cost_minus_zero_query_kv As Array = {""RecordDate"", DateToSQL(Now)}
		Dim cost_minus_zero = QData(cost_minus_zero_query, con_string, cost_minus_zero_query_kv)

		Dim gain_minus_two_query As String = BuildSumString_UNGROUPED(""Sales"", ""Totalgain"", {""RecordDate""})
		Dim gain_minus_two_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, -2, Now))}
		Dim gain_minus_two = QData(gain_minus_two_query, con_string, gain_minus_two_query_kv)

		Dim gain_minus_one_query As String = BuildSumString_UNGROUPED(""Sales"", ""Totalgain"", {""RecordDate""})
		Dim gain_minus_one_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, -1, Now))}
		Dim gain_minus_one = QData(gain_minus_one_query, con_string, gain_minus_one_query_kv)

		Dim gain_minus_zero_query As String = BuildSumString_UNGROUPED(""Sales"", ""Totalgain"", {""RecordDate""})
		Dim gain_minus_zero_query_kv As Array = {""RecordDate"", DateToSQL(Now)}
		Dim gain_minus_zero = QData(gain_minus_zero_query, con_string, gain_minus_zero_query_kv)


		Dim x As New List(Of String)
		With x
			.Add(DateAdd(DateInterval.Day, -2, Now).ToShortDateString)
			.Add(DateAdd(DateInterval.Day, -1, Now).ToShortDateString)
			.Add(Now.ToShortDateString)
		End With

		Dim x_cost_values As New List(Of String)
		With x_cost_values
			.Add(cost_minus_two)
			.Add(cost_minus_one)
			.Add(cost_minus_zero)
		End With

		Dim x_gain_values As New List(Of String)
		With x_gain_values
			.Add(gain_minus_two)
			.Add(gain_minus_one)
			.Add(gain_minus_zero)
		End With

		Dim cost_data_set As New BarChartDataSet With {.color_ = RandomColor(New List(Of Integer)), .x_values_for_each_x_label = x_cost_values, .legend_value = ""Cost""}
		Dim gain_data_set As New BarChartDataSet With {.color_ = RandomColor(New List(Of Integer)), .x_values_for_each_x_label = x_gain_values, .legend_value = ""Gain""}

		Dim l As New List(Of BarChartDataSet)
		With l
			.Add(cost_data_set)
			.Add(gain_data_set)
		End With

		BarChart(x, l, divCostVsGainChart, divCostVsGainLegend, divCostVsGainTitle, ""Cost vs Gain"")


#End Region

#Region ""Sales - Cost vs Gain - Custom""

		Dim query_cost_gain As String = BuildSelectString_DISTINCT(""Sales"", {""RecordDate""})
		Dim list_sales_dates__ As List(Of String) = QList(query_cost_gain, con_string)
		Dim list_cost_gain_dates As New List(Of String)
		With list_sales_dates__
			For i = 0 To .Count - 1
				list_cost_gain_dates.Add(""From  "" & list_sales_dates__(i))
			Next
		End With
		BindProperty(dropSalesDates, list_cost_gain_dates)

#End Region

#Region ""Sales - Invoice Count""
		Dim invoice_count_minus_two_query As String = BuildSelectString_DISTINCT(""Sales"", {""ReceiptNumber""}, {""RecordDate""})
		Dim invoice_count_minus_two_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, -2, Now))}
		Dim invoice_count_minus_two = Display(gridInvoiceCount, invoice_count_minus_two_query, con_string, invoice_count_minus_two_query_kv).Rows.Count

		Dim invoice_count_minus_one_query As String = BuildSelectString_DISTINCT(""Sales"", {""ReceiptNumber""}, {""RecordDate""})
		Dim invoice_count_minus_one_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, -1, Now))}
		Dim invoice_count_minus_one = Display(gridInvoiceCount, invoice_count_minus_one_query, con_string, invoice_count_minus_one_query_kv).Rows.Count

		Dim invoice_count_minus_zero_query As String = BuildSelectString_DISTINCT(""Sales"", {""ReceiptNumber""}, {""RecordDate""})
		Dim invoice_count_minus_zero_query_kv As Array = {""RecordDate"", DateToSQL(Now)}
		Dim invoice_count_minus_zero = Display(gridInvoiceCount, invoice_count_minus_zero_query, con_string, invoice_count_minus_zero_query_kv).Rows.Count

		Dim x_invoice_count As New List(Of String)
		With x_invoice_count
			.Add(DateAdd(DateInterval.Day, -2, Now).ToShortDateString)
			.Add(DateAdd(DateInterval.Day, -1, Now).ToShortDateString)
			.Add(Now.ToShortDateString)
		End With

		Dim x_invoice_count_values As New List(Of String)
		With x_invoice_count_values
			.Add(invoice_count_minus_two)
			.Add(invoice_count_minus_one)
			.Add(invoice_count_minus_zero)
		End With

		Dim invoice_count_data_set As New BarChartDataSet With {.color_ = RandomColor(New List(Of Integer)), .x_values_for_each_x_label = x_invoice_count_values, .legend_value = ""Total Receipts""}

		Dim l_invoice_count As New List(Of BarChartDataSet)
		With l_invoice_count
			.Add(invoice_count_data_set)
		End With

		BarChart(x_invoice_count, l_invoice_count, divInvoiceCountChart, Nothing, divInvoiceCountTitle, ""Total Receipts"")

#End Region

#Region ""Sales - Invoice Count - Custom""

		Dim list_invoice_count_dates As New List(Of String)
		With list_sales_dates__
			For i = 0 To .Count - 1
				list_invoice_count_dates.Add(""From  "" & list_sales_dates__(i))
			Next
		End With
		BindProperty(dropInvoiceCountDates, list_invoice_count_dates)

#End Region

#Region ""Sales - Quantity Sold Today""
		Dim quantity_sold_minus_two_query As String = BuildSumString_UNGROUPED(""Sales"", ""Quantity"", {""RecordDate""})
		Dim quantity_sold_minus_two_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, -2, Now))}
		Dim quantity_sold_minus_two = QData(quantity_sold_minus_two_query, con_string, quantity_sold_minus_two_query_kv)

		Dim quantity_sold_minus_one_query As String = BuildSumString_UNGROUPED(""Sales"", ""Quantity"", {""RecordDate""})
		Dim quantity_sold_minus_one_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, -1, Now))}
		Dim quantity_sold_minus_one = QData(quantity_sold_minus_one_query, con_string, quantity_sold_minus_one_query_kv)

		Dim quantity_sold_minus_zero_query As String = BuildSumString_UNGROUPED(""Sales"", ""Quantity"", {""RecordDate""})
		Dim quantity_sold_minus_zero_query_kv As Array = {""RecordDate"", DateToSQL(Now)}
		Dim quantity_sold_minus_zero = QData(quantity_sold_minus_zero_query, con_string, quantity_sold_minus_zero_query_kv)

		Dim x_quantity_sold As New List(Of String)
		With x_quantity_sold
			.Add(DateAdd(DateInterval.Day, -2, Now).ToShortDateString)
			.Add(DateAdd(DateInterval.Day, -1, Now).ToShortDateString)
			.Add(Now.ToShortDateString)
		End With

		Dim x_quantity_sold_values As New List(Of String)
		With x_quantity_sold_values
			.Add(quantity_sold_minus_two)
			.Add(quantity_sold_minus_one)
			.Add(quantity_sold_minus_zero)
		End With

		Dim quantity_sold_data_set As New BarChartDataSet With {.color_ = RandomColor(New List(Of Integer)), .x_values_for_each_x_label = x_quantity_sold_values, .legend_value = ""Total Products Sold""}

		Dim l_quantity_sold As New List(Of BarChartDataSet)
		With l_quantity_sold
			.Add(quantity_sold_data_set)
		End With

		BarChart(x_quantity_sold, l_quantity_sold, divQuantitySoldChart, Nothing, divQuantitySoldTitle, ""Total Products Sold"")

#End Region

#Region ""Sales - Quantity Sold - Custom""
		Dim list_quantity_sold_dates As New List(Of String)
		With list_sales_dates__
			For i = 0 To .Count - 1
				list_quantity_sold_dates.Add(""From  "" & list_sales_dates__(i))
			Next
		End With

		BindProperty(dropQuantitySoldDates, list_quantity_sold_dates)

#End Region

#Region ""Products - Quantity In Each Category""
		PieSum(gridProducts, ""Products"", ""Category"", ""Quantity"", con_string, divQuanitityPerCategoryChart, {""RecordCreatedOn""}, {""RecordCreatedOn"", DateToSQL(Now)}, divQuanitityPerCategoryLegend, divQuanitityPerCategoryTitle, ""Quantity Of Products Per Category Today"")
#End Region

#Region ""Products - Quantity In Each Category - Custom""
		'dates
		Dim list_products_dates__ As List(Of String) = QList(BuildSelectString_DISTINCT(""Products"", {""RecordCreatedOn""}, Nothing), con_string)
		Dim list_products_dates As New List(Of String)
		With list_products_dates__
			For i = 0 To .Count - 1
				list_products_dates.Add(""On  "" & list_products_dates__(i))
			Next
		End With
		BindProperty(dropRecordCreatedOnDates, list_products_dates)

#End Region

#Region ""Sales - Top Selling""
		Dim list_top_selling_dates As New List(Of String)
		With list_sales_dates__
			For i = 0 To .Count - 1
				list_top_selling_dates.Add(""On  "" & list_sales_dates__(i))
			Next
		End With
		BindProperty(dropTopSellingDates, list_top_selling_dates)

		divTopSellingTitle.InnerText = ""Top 10 Best Selling Products Today""
		Display(gridTopSelling, BuildTopString(""Sales"", {""Name AS 'Name'"", ""Category AS 'Category'"", ""Quantity""}, {""RecordDate""}, 10, ""Quantity"", OrderBy.DESC), con_string, {""RecordDate"", DateToSQL(Now)})


#End Region

#Region ""Sales - Least Selling""
		Dim list_least_selling_dates As New List(Of String)
		With list_sales_dates__
			For i = 0 To .Count - 1
				list_least_selling_dates.Add(""On  "" & list_sales_dates__(i))
			Next
		End With
		BindProperty(dropLeastSellingDates, list_top_selling_dates)

		divLeastSellingTitle.InnerHtml = ""Top 10 Least Selling Products Today""
		Display(gridLeastSelling, BuildTopString(""Sales"", {""Name AS 'Name'"", ""Category AS 'Category'"", ""Quantity""}, {""RecordDate""}, 10, ""Quantity"", OrderBy.ASC), con_string, {""RecordDate"", DateToSQL(Now)})
#End Region

#Region ""Sales - Paying Customers Count""
		Dim customers_count_minus_two_query As String = BuildSelectString_DISTINCT(""Sales"", {""CustomerID""}, {""RecordDate""})
		Dim customers_count_minus_two_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, -2, Now))}
		Dim customers_count_minus_two = Display(gridCustomersCount, customers_count_minus_two_query, con_string, customers_count_minus_two_query_kv).Rows.Count

		Dim customers_count_minus_one_query As String = BuildSelectString_DISTINCT(""Sales"", {""CustomerID""}, {""RecordDate""})
		Dim customers_count_minus_one_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, -1, Now))}
		Dim customers_count_minus_one = Display(gridCustomersCount, customers_count_minus_one_query, con_string, customers_count_minus_one_query_kv).Rows.Count

		Dim customers_count_minus_zero_query As String = BuildSelectString_DISTINCT(""Sales"", {""CustomerID""}, {""RecordDate""})
		Dim customers_count_minus_zero_query_kv As Array = {""RecordDate"", DateToSQL(Now)}
		Dim customers_count_minus_zero = Display(gridCustomersCount, customers_count_minus_zero_query, con_string, customers_count_minus_zero_query_kv).Rows.Count

		Dim x_customers_count As New List(Of String)
		With x_customers_count
			.Add(DateAdd(DateInterval.Day, -2, Now).ToShortDateString)
			.Add(DateAdd(DateInterval.Day, -1, Now).ToShortDateString)
			.Add(Now.ToShortDateString)
		End With

		Dim x_customers_count_values As New List(Of String)
		With x_customers_count_values
			.Add(customers_count_minus_two)
			.Add(customers_count_minus_one)
			.Add(customers_count_minus_zero)
		End With

		Dim customers_count_data_set As New BarChartDataSet With {.color_ = RandomColor(New List(Of Integer)), .x_values_for_each_x_label = x_customers_count_values, .legend_value = ""Total Paying Customers""}

		Dim l_customers_count As New List(Of BarChartDataSet)
		With l_customers_count
			.Add(customers_count_data_set)
		End With

		BarChart(x_customers_count, l_customers_count, divCustomersCountChart, Nothing, divCustomersCountTitle, ""Total Paying Customers"")

#End Region

#Region ""Sales - Paying Customers Count - Custom""
		Dim list_customers_count_dates As New List(Of String)
		With list_sales_dates__
			For i = 0 To .Count - 1
				list_customers_count_dates.Add(""From  "" & list_sales_dates__(i))
			Next
		End With

		BindProperty(dropCustomersCountDates, list_customers_count_dates)

#End Region

#Region ""Sales - Top Paying Customer""
		TopPayingCustomersGrid()
#End Region

"
	End Function
	Public Function DashboardECommerceMethods() As String
		Return "	Private Sub TopPayingCustomersGrid()
		divTopPayingCustomersTitle.InnerText = ""Top Paying Customers For All Time""
		Dim top_paying_customers_query As String = ""SELECT CustomerID AS 'Customer ID', [CustomerName] AS 'Name', SUM(TotalGain) AS 'Total Spending'  FROM Sales GROUP BY CustomerID, [CustomerName] ORDER BY [Total Spending] DESC""
		Display(gridTopPayingCustomers, top_paying_customers_query, con_string)
	End Sub

	Protected Sub buttonSalesCostGain_Click(sender As Object, e As EventArgs)
		Dim selected = Date.Parse(Content(dropSalesDates).Replace(""From  "", """"))

		Dim cost_minus_two_query As String = BuildSumString_UNGROUPED(""Sales"", ""TotalCost"", {""RecordDate""})
		Dim cost_minus_two_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, +0, selected))}
		Dim cost_minus_two = QData(cost_minus_two_query, con_string, cost_minus_two_query_kv)

		Dim cost_minus_one_query As String = BuildSumString_UNGROUPED(""Sales"", ""TotalCost"", {""RecordDate""})
		Dim cost_minus_one_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, +1, selected))}
		Dim cost_minus_one = QData(cost_minus_one_query, con_string, cost_minus_one_query_kv)

		Dim cost_minus_zero_query As String = BuildSumString_UNGROUPED(""Sales"", ""TotalCost"", {""RecordDate""})
		Dim cost_minus_zero_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, +2, selected))}
		Dim cost_minus_zero = QData(cost_minus_zero_query, con_string, cost_minus_zero_query_kv)

		Dim gain_minus_two_query As String = BuildSumString_UNGROUPED(""Sales"", ""Totalgain"", {""RecordDate""})
		Dim gain_minus_two_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, +0, selected))}
		Dim gain_minus_two = QData(gain_minus_two_query, con_string, gain_minus_two_query_kv)

		Dim gain_minus_one_query As String = BuildSumString_UNGROUPED(""Sales"", ""Totalgain"", {""RecordDate""})
		Dim gain_minus_one_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, +1, selected))}
		Dim gain_minus_one = QData(gain_minus_one_query, con_string, gain_minus_one_query_kv)

		Dim gain_minus_zero_query As String = BuildSumString_UNGROUPED(""Sales"", ""Totalgain"", {""RecordDate""})
		Dim gain_minus_zero_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, +2, selected))}
		Dim gain_minus_zero = QData(gain_minus_zero_query, con_string, gain_minus_zero_query_kv)


		Dim x As New List(Of String)
		With x
			.Add(DateAdd(DateInterval.Day, +0, selected).ToShortDateString)
			.Add(DateAdd(DateInterval.Day, +1, selected).ToShortDateString)
			.Add(DateAdd(DateInterval.Day, +2, selected).ToShortDateString)
		End With

		Dim x_cost_values As New List(Of String)
		With x_cost_values
			.Add(cost_minus_two)
			.Add(cost_minus_one)
			.Add(cost_minus_zero)
		End With

		Dim x_gain_values As New List(Of String)
		With x_gain_values
			.Add(gain_minus_two)
			.Add(gain_minus_one)
			.Add(gain_minus_zero)
		End With

		Dim cost_data_set As New BarChartDataSet With {.color_ = RandomColor(New List(Of Integer)), .x_values_for_each_x_label = x_cost_values, .legend_value = ""Cost""}
		Dim gain_data_set As New BarChartDataSet With {.color_ = RandomColor(New List(Of Integer)), .x_values_for_each_x_label = x_gain_values, .legend_value = ""Gain""}

		Dim l As New List(Of BarChartDataSet)
		With l
			.Add(cost_data_set)
			.Add(gain_data_set)
		End With

		BarChart(x, l, divCostVsGainChart, divCostVsGainLegend, divCostVsGainTitle)

	End Sub

	Protected Sub buttonInvoiceCount_Click(sender As Object, e As EventArgs)
		Dim selected = Date.Parse(Content(dropInvoiceCountDates).Replace(""From  "", """"))

		Dim invoice_count_minus_two_query As String = BuildSelectString_DISTINCT(""Sales"", {""ReceiptNumber""}, {""RecordDate""})
		Dim invoice_count_minus_two_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, +0, selected))}
		Dim invoice_count_minus_two = Display(gridInvoiceCount, invoice_count_minus_two_query, con_string, invoice_count_minus_two_query_kv).Rows.Count

		Dim invoice_count_minus_one_query As String = BuildSelectString_DISTINCT(""Sales"", {""ReceiptNumber""}, {""RecordDate""})
		Dim invoice_count_minus_one_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, +1, selected))}
		Dim invoice_count_minus_one = Display(gridInvoiceCount, invoice_count_minus_one_query, con_string, invoice_count_minus_one_query_kv).Rows.Count

		Dim invoice_count_minus_zero_query As String = BuildSelectString_DISTINCT(""Sales"", {""ReceiptNumber""}, {""RecordDate""})
		Dim invoice_count_minus_zero_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, +2, selected))}
		Dim invoice_count_minus_zero = Display(gridInvoiceCount, invoice_count_minus_zero_query, con_string, invoice_count_minus_zero_query_kv).Rows.Count

		Dim x_invoice_count As New List(Of String)
		With x_invoice_count
			.Add(DateAdd(DateInterval.Day, +0, selected).ToShortDateString)
			.Add(DateAdd(DateInterval.Day, +1, selected).ToShortDateString)
			.Add(DateAdd(DateInterval.Day, +2, selected).ToShortDateString)
		End With

		Dim x_invoice_count_values As New List(Of String)
		With x_invoice_count_values
			.Add(invoice_count_minus_two)
			.Add(invoice_count_minus_one)
			.Add(invoice_count_minus_zero)
		End With

		Dim invoice_count_data_set As New BarChartDataSet With {.color_ = RandomColor(New List(Of Integer)), .x_values_for_each_x_label = x_invoice_count_values, .legend_value = ""Total Receipts""}

		Dim l_invoice_count As New List(Of BarChartDataSet)
		With l_invoice_count
			.Add(invoice_count_data_set)
		End With

		BarChart(x_invoice_count, l_invoice_count, divInvoiceCountChart, Nothing, divInvoiceCountTitle, ""Total Receipts"")

	End Sub

	Protected Sub buttonQuantitySold_Click(sender As Object, e As EventArgs)
		Dim selected = Date.Parse(Content(dropQuantitySoldDates).Replace(""From  "", """"))

		Dim quantity_sold_minus_two_query As String = BuildSumString_UNGROUPED(""Sales"", ""Quantity"", {""RecordDate""})
		Dim quantity_sold_minus_two_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, +0, selected))}
		Dim quantity_sold_minus_two = QData(quantity_sold_minus_two_query, con_string, quantity_sold_minus_two_query_kv)

		Dim quantity_sold_minus_one_query As String = BuildSumString_UNGROUPED(""Sales"", ""Quantity"", {""RecordDate""})
		Dim quantity_sold_minus_one_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, +1, selected))}
		Dim quantity_sold_minus_one = QData(quantity_sold_minus_one_query, con_string, quantity_sold_minus_one_query_kv)

		Dim quantity_sold_minus_zero_query As String = BuildSumString_UNGROUPED(""Sales"", ""Quantity"", {""RecordDate""})
		Dim quantity_sold_minus_zero_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, +2, selected))}
		Dim quantity_sold_minus_zero = QData(quantity_sold_minus_zero_query, con_string, quantity_sold_minus_zero_query_kv)

		Dim x_quantity_sold As New List(Of String)
		With x_quantity_sold
			.Add(DateAdd(DateInterval.Day, +0, selected).ToShortDateString)
			.Add(DateAdd(DateInterval.Day, +1, selected).ToShortDateString)
			.Add(DateAdd(DateInterval.Day, +2, selected).ToShortDateString)
		End With

		Dim x_quantity_sold_values As New List(Of String)
		With x_quantity_sold_values
			.Add(quantity_sold_minus_two)
			.Add(quantity_sold_minus_one)
			.Add(quantity_sold_minus_zero)
		End With

		Dim quantity_sold_data_set As New BarChartDataSet With {.color_ = RandomColor(New List(Of Integer)), .x_values_for_each_x_label = x_quantity_sold_values, .legend_value = ""Quantity Sold""}

		Dim l_quantity_sold As New List(Of BarChartDataSet)
		With l_quantity_sold
			.Add(quantity_sold_data_set)
		End With

		BarChart(x_quantity_sold, l_quantity_sold, divQuantitySoldChart, Nothing, divQuantitySoldTitle, ""Quantity Sold"")
	End Sub

	Protected Sub buttonQuanitityPerCategory_Click(sender As Object, e As EventArgs)
		Select Case Content(dropChartQuantityPerCategory)
			Case ChartIs.Doughnut.ToString
				DoughnutSum(gridQuanitityPerCategory, ""Products"", ""Category"", ""Quantity"", con_string, divQuanitityPerCategoryChart, {""RecordCreatedOn""}, {""RecordCreatedOn"", DateToSQL(Content(dropRecordCreatedOnDates).Replace(""On  "", """"))}, divQuanitityPerCategoryLegend, divQuanitityPerCategoryTitle, ""Quantity Of Products Per Category On "" & Date.Parse(Content(dropRecordCreatedOnDates).Replace(""On  "", """")).ToLongDateString)
			Case Else
				PieSum(gridQuanitityPerCategory, ""Products"", ""Category"", ""Quantity"", con_string, divQuanitityPerCategoryChart, {""RecordCreatedOn""}, {""RecordCreatedOn"", DateToSQL(Content(dropRecordCreatedOnDates).Replace(""On  "", """"))}, divQuanitityPerCategoryLegend, divQuanitityPerCategoryTitle, ""Quantity Of Products Per Category On "" & Date.Parse(Content(dropRecordCreatedOnDates).Replace(""On  "", """")).ToLongDateString)
		End Select
	End Sub

	Protected Sub buttonTopSelling_Click(sender As Object, e As EventArgs)
		If IsEmpty(textTopSellingTop) Or Val(Content(textTopSellingTop)) < 1 Then
			textTopSellingTop.Text = ""10""
		End If
		divTopSellingTitle.InnerText = ""Top "" & Val(Content(textTopSellingTop)) & "" Best Selling Products On "" & Date.Parse(Content(dropTopSellingDates).Replace(""On  "", """")).ToLongDateString
		Display(gridTopSelling, BuildTopString(""Sales"", {""Name AS 'Name'"", ""Category AS 'Category'"", ""Quantity""}, {""RecordDate""}, Val(Content(textTopSellingTop)), ""Quantity"", OrderBy.DESC), con_string, {""RecordDate"", DateToSQL(Content(dropTopSellingDates).Replace(""On  "", """"))})
	End Sub

	Protected Sub buttonLeastSelling_Click(sender As Object, e As EventArgs)
		If IsEmpty(textLeastSellingTop) Or Val(Content(textLeastSellingTop)) < 1 Then
			textLeastSellingTop.Text = ""10""
		End If
		divLeastSellingTitle.InnerHtml = ""Top "" & Val(Content(textLeastSellingTop)) & "" Least Selling Products On "" & Date.Parse(Content(dropLeastSellingDates).Replace(""On  "", """")).ToLongDateString
		Display(gridLeastSelling, BuildTopString(""Sales"", {""Name AS 'Name'"", ""Category AS 'Category'"", ""Quantity""}, {""RecordDate""}, Val(Content(textLeastSellingTop)), ""Quantity"", OrderBy.ASC), con_string, {""RecordDate"", DateToSQL(Content(dropLeastSellingDates).Replace(""On  "", """"))})
	End Sub

	Protected Sub buttonCustomersCount_Click(sender As Object, e As EventArgs)
		Dim selected = Date.Parse(Content(dropCustomersCountDates).Replace(""From  "", """"))

		Dim customers_count_minus_two_query As String = BuildSelectString_DISTINCT(""Sales"", {""CustomerID""}, {""RecordDate""})
		Dim customers_count_minus_two_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, +0, selected))}
		Dim customers_count_minus_two = Display(gridCustomersCount, customers_count_minus_two_query, con_string, customers_count_minus_two_query_kv).Rows.Count

		Dim customers_count_minus_one_query As String = BuildSelectString_DISTINCT(""Sales"", {""CustomerID""}, {""RecordDate""})
		Dim customers_count_minus_one_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, +1, selected))}
		Dim customers_count_minus_one = Display(gridCustomersCount, customers_count_minus_one_query, con_string, customers_count_minus_one_query_kv).Rows.Count

		Dim customers_count_minus_zero_query As String = BuildSelectString_DISTINCT(""Sales"", {""CustomerID""}, {""RecordDate""})
		Dim customers_count_minus_zero_query_kv As Array = {""RecordDate"", DateToSQL(DateAdd(DateInterval.Day, +2, selected))}
		Dim customers_count_minus_zero = Display(gridCustomersCount, customers_count_minus_zero_query, con_string, customers_count_minus_zero_query_kv).Rows.Count

		Dim x_customers_count As New List(Of String)
		With x_customers_count
			.Add(DateAdd(DateInterval.Day, +0, selected).ToShortDateString)
			.Add(DateAdd(DateInterval.Day, +1, selected).ToShortDateString)
			.Add(DateAdd(DateInterval.Day, +2, selected).ToShortDateString)
		End With

		Dim x_customers_count_values As New List(Of String)
		With x_customers_count_values
			.Add(customers_count_minus_two)
			.Add(customers_count_minus_one)
			.Add(customers_count_minus_zero)
		End With

		Dim customers_count_data_set As New BarChartDataSet With {.color_ = RandomColor(New List(Of Integer)), .x_values_for_each_x_label = x_customers_count_values, .legend_value = ""Total Paying Customers""}

		Dim l_customers_count As New List(Of BarChartDataSet)
		With l_customers_count
			.Add(customers_count_data_set)
		End With

		BarChart(x_customers_count, l_customers_count, divCustomersCountChart, Nothing, divCustomersCountTitle, ""Total Paying Customers"")

	End Sub

	Private Sub gridTopPayingCustomers_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gridTopPayingCustomers.PageIndexChanging
		gridTopPayingCustomers.PageIndex = e.NewPageIndex
		TopPayingCustomersGrid()
	End Sub
"
	End Function
	Public Function DashboardECommerceMarkup() As String
		Return "<asp:Content ID=""BodyContent"" ContentPlaceHolderID=""MainContent"" runat=""server"">
    <br />
    <br />

    <%--cost/gain--%>
    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""row"">
                <div class=""col-sm-12"" id=""divCostVsGainChart"" runat=""server"">
                </div>
            </div>
            <div class=""row"">
                <div class=""col-sm-12"" id=""divCostVsGainLegend"" runat=""server"" style=""text-align: left""></div>
            </div>
            <br />
            <div class=""row"" style=""display: inline-flex; text-align: center; padding-left: 30px; padding-top: 10px"">
                <div class=""col-sm-12"" id=""divCostVsGainTitle"" runat=""server"" style=""text-align: center; font-weight: 600""></div>
            </div>
            <br />
            <div class=""row"">
                <div class=""col-sm-12"" style=""display: inline-flex; vertical-align: middle; padding-left: 30px"">
                    <asp:DropDownList ID=""dropSalesDates"" runat=""server"" class=""form-control"" ValidationGroup=""default""></asp:DropDownList>
                    &nbsp; &nbsp;
                    <asp:DropDownList ID=""dropChartCostVsGain"" runat=""server"" class=""form-control""></asp:DropDownList>
                    &nbsp; &nbsp;
                    <asp:Button ID=""buttonSalesCostGain"" runat=""server"" Text=""Show"" CssClass=""btn btn-primary btn-sm"" CausesValidation=""false"" ValidationGroup=""default"" OnClick=""buttonSalesCostGain_Click"" />
                </div>
            </div>
        </div>
    </div>

    <br />
    <br />
    <br />
    <br />

    <%--quantity of products per category--%>
    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""row"">
                <div class=""col-sm-12"" id=""divQuanitityPerCategoryChart"" runat=""server"">
                </div>
            </div>
            <div class=""row"">
                <div class=""col-sm-12"" id=""divQuanitityPerCategoryLegend"" runat=""server"" style=""text-align: left""></div>
            </div>
            <br />
            <div class=""row"" style=""display: inline-flex; text-align: center; padding-left: 30px; padding-top: 10px"">
                <div class=""col-sm-12"" id=""divQuanitityPerCategoryTitle"" runat=""server"" style=""text-align: center; font-weight: 600""></div>
            </div>
            <br />
            <div class=""row"">
                <div class=""col-sm-12"" style=""display: inline-flex; vertical-align: middle; padding-left: 30px"">
                    <asp:DropDownList ID=""dropRecordCreatedOnDates"" runat=""server"" class=""form-control"" ValidationGroup=""default""></asp:DropDownList>
                    &nbsp; &nbsp;
                    <asp:DropDownList ID=""dropChartQuantityPerCategory"" runat=""server"" class=""form-control""></asp:DropDownList>
                    &nbsp; &nbsp;
                    <asp:Button ID=""buttonQuanitityPerCategory"" runat=""server"" Text=""Show"" CssClass=""btn btn-primary btn-sm"" CausesValidation=""false"" ValidationGroup=""default"" OnClick=""buttonQuanitityPerCategory_Click"" />
                </div>
            </div>
        </div>
    </div>

    <br />
    <br />
    <br />
    <br />

    <%--top 10 best selling product--%>
    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""row"">
                <div class=""col-sm-12"">
                    <div class=""work-progres"">
                        <div class=""chit-chat-heading"" id=""divTopSellingTitle"" runat=""server"">
                        </div>
                        <div class=""table-responsive"">
                            <asp:GridView runat=""server"" ID=""gridTopSelling"" CssClass=""table table-hover""></asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class=""row"">
                <div class=""col-sm-12"" style=""display: inline-flex; vertical-align: middle; padding-left: 30px"">
                    <asp:DropDownList ID=""dropTopSellingDates"" runat=""server"" class=""form-control"" ValidationGroup=""default""></asp:DropDownList>
                    &nbsp; &nbsp;
                    <asp:TextBox ID=""textTopSellingTop"" runat=""server"" TextMode=""Number"" Text=""10"" CausesValidation=""true"" CssClass=""form-control"" />
                    &nbsp; &nbsp;
                    <asp:Button ID=""buttonTopSelling"" runat=""server"" Text=""Show"" CssClass=""btn btn-primary btn-sm"" CausesValidation=""false"" ValidationGroup=""default"" OnClick=""buttonTopSelling_Click"" />
                </div>
            </div>
        </div>
    </div>


    <br />
    <br />
    <br />
    <br />

    <%--top 10 least selling product--%>
    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""row"">
                <div class=""col-sm-12"">
                    <div class=""work-progres"">
                        <div class=""chit-chat-heading"" id=""divLeastSellingTitle"" runat=""server"">
                        </div>
                        <div class=""table-responsive"">
                            <asp:GridView runat=""server"" ID=""gridLeastSelling"" CssClass=""table table-hover""></asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class=""row"">
                <div class=""col-sm-12"" style=""display: inline-flex; vertical-align: middle; padding-left: 30px"">
                    <asp:DropDownList ID=""dropLeastSellingDates"" runat=""server"" class=""form-control"" ValidationGroup=""default""></asp:DropDownList>
                    &nbsp; &nbsp;
                    <asp:TextBox ID=""textLeastSellingTop"" runat=""server"" TextMode=""Number"" Text=""10"" CausesValidation=""true"" CssClass=""form-control"" />
                    &nbsp; &nbsp;
                    <asp:Button ID=""buttonLeastSelling"" runat=""server"" Text=""Show"" CssClass=""btn btn-primary btn-sm"" CausesValidation=""false"" ValidationGroup=""default"" OnClick=""buttonLeastSelling_Click"" />
                </div>
            </div>
        </div>
    </div>

    <br />
    <br />
    <br />
    <br />

    <%--invoice count--%>
    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""row"">
                <div class=""col-sm-12"" runat=""server"" id=""divInvoiceCountChart"">
                </div>
            </div>
            <div class=""row"">
                <div class=""col-sm-12"" id=""divInvoiceCountLegend"" runat=""server"" style=""text-align: left""></div>
            </div>
            <br />
            <div class=""row"" style=""display: inline-flex; text-align: center; padding-left: 30px; padding-top: 10px"">
                <div class=""col-sm-12"" id=""divInvoiceCountTitle"" runat=""server"" style=""text-align: center; font-weight: 600""></div>
            </div>
            <br />
            <div class=""row"">
                <div class=""col-sm-12"" style=""display: inline-flex; vertical-align: middle; padding-left: 30px"">
                    <asp:DropDownList ID=""dropInvoiceCountDates"" runat=""server"" class=""form-control"" ValidationGroup=""default""></asp:DropDownList>
                    &nbsp; &nbsp;
                    <asp:DropDownList ID=""dropChartInvoiceCount"" runat=""server"" class=""form-control""></asp:DropDownList>
                    &nbsp; &nbsp;
                    <asp:Button ID=""buttonInvoiceCount"" runat=""server"" Text=""Show"" CssClass=""btn btn-primary btn-sm"" CausesValidation=""false"" ValidationGroup=""default"" OnClick=""buttonInvoiceCount_Click"" />
                </div>
            </div>
        </div>
    </div>

    <br />
    <br />
    <br />
    <br />

    <%--quantity sold--%>
    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""row"">
                <div class=""col-sm-12"" runat=""server"" id=""divQuantitySoldChart"">
                </div>
            </div>
            <div class=""row"">
                <div class=""col-sm-12"" id=""divQuantitySoldLegend"" runat=""server"" style=""text-align: left""></div>
            </div>
            <br />
            <div class=""row"" style=""display: inline-flex; text-align: center; padding-left: 30px; padding-top: 10px"">
                <div class=""col-sm-12"" id=""divQuantitySoldTitle"" runat=""server"" style=""text-align: center; font-weight: 600""></div>
            </div>
            <br />
            <div class=""row"">
                <div class=""col-sm-12"" style=""display: inline-flex; vertical-align: middle; padding-left: 30px"">
                    <asp:DropDownList ID=""dropQuantitySoldDates"" runat=""server"" class=""form-control"" ValidationGroup=""default""></asp:DropDownList>
                    &nbsp; &nbsp;
                    <asp:DropDownList ID=""dropChartQuantitySold"" runat=""server"" class=""form-control""></asp:DropDownList>
                    &nbsp; &nbsp;
                    <asp:Button ID=""buttonQuantitySold"" runat=""server"" Text=""Show"" CssClass=""btn btn-primary btn-sm"" CausesValidation=""false"" ValidationGroup=""default"" OnClick=""buttonQuantitySold_Click"" />
                </div>
            </div>
        </div>
    </div>

    <br />
    <br />
    <br />
    <br />

    <%--total number of customers--%>
    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""row"">
                <div class=""col-sm-12"" runat=""server"" id=""divCustomersCountChart"">
                </div>
            </div>
            <div class=""row"">
                <div class=""col-sm-12"" id=""divCustomersCountLegend"" runat=""server"" style=""text-align: left""></div>
            </div>
            <br />
            <div class=""row"" style=""display: inline-flex; text-align: center; padding-left: 30px; padding-top: 10px"">
                <div class=""col-sm-12"" id=""divCustomersCountTitle"" runat=""server"" style=""text-align: center; font-weight: 600""></div>
            </div>
            <br />
            <div class=""row"">
                <div class=""col-sm-12"" style=""display: inline-flex; vertical-align: middle; padding-left: 30px"">
                    <asp:DropDownList ID=""dropCustomersCountDates"" runat=""server"" class=""form-control"" ValidationGroup=""default""></asp:DropDownList>
                    &nbsp; &nbsp;
                    <asp:DropDownList ID=""dropChartCustomersCount"" runat=""server"" class=""form-control""></asp:DropDownList>
                    &nbsp; &nbsp;
                    <asp:Button ID=""buttonCustomersCount"" runat=""server"" Text=""Show"" CssClass=""btn btn-primary btn-sm"" CausesValidation=""false"" ValidationGroup=""default"" OnClick=""buttonCustomersCount_Click"" />
                </div>
            </div>
        </div>
    </div>


    <br />
    <br />
    <br />
    <br />

    <%--top 10 highest paying customers--%>
    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""row"">
                <div class=""col-sm-12"">
                    <div class=""work-progres"">
                        <div class=""chit-chat-heading"" id=""divTopPayingCustomersTitle"" runat=""server"">
                        </div>
                        <div class=""table-responsive"">
                            <asp:GridView ID=""gridTopPayingCustomers"" CssClass=""table table-hover"" runat=""server"" AllowPaging=""true"" PagerSettings-Mode=""NextPreviousFirstLast"" PagerSettings-Position=""TopAndBottom"" EnableSortingAndPagingCallbacks=""true"" PagerStyle-HorizontalAlign=""Left"" PageSize=""10"" PagerSettings-NextPageText='<span><i class=""fa fa-chevron-circle-right"" aria-hidden=""true""></i></span>' PagerSettings-PreviousPageText='<span><i class=""fa fa-chevron-circle-left"" aria-hidden=""true""></i></span>' PagerSettings-LastPageText='<span><i class=""fa fa-chevron-right"" aria-hidden=""true""></i></span>' PagerSettings-FirstPageText='<span><i class=""fa fa-home"" aria-hidden=""true""></i></span>'></asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <asp:PlaceHolder runat=""server"" Visible=""false"">

        <asp:GridView runat=""server"" ID=""gridCostVsGain""></asp:GridView>
        <asp:GridView runat=""server"" ID=""gridInvoiceCount""></asp:GridView>
        <asp:GridView runat=""server"" ID=""gridQuanitityPerCategory""></asp:GridView>
        <asp:GridView runat=""server"" ID=""gridQuantityLastModifiedDates""></asp:GridView>
        <asp:GridView runat=""server"" ID=""gridCustomersCount""></asp:GridView>

        <asp:GridView runat=""server"" ID=""gridProducts""></asp:GridView>


        <asp:GridView runat=""server"" ID=""AvgSumPrice""></asp:GridView>
    </asp:PlaceHolder>

</asp:Content>
"
	End Function

#End Region


End Class
