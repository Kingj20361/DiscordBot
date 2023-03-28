using System.IO;
using System.Threading.Tasks;
using Discord.Commands;
using OfficeOpenXml;

public class ExcelCommands : ModuleBase<SocketCommandContext>
{
    [Command("lookup")]
    public async Task LookupAsync(string searchValue)
    {
        // Load the Excel spreadsheet from a file path
        using (var excelPackage = new ExcelPackage(new FileInfo("path/to/excel/file.xlsx")))
        {
            // Get the worksheet you want to read from
            var worksheet = excelPackage.Workbook.Worksheets["Sheet1"];

            // Loop through each row in column A
            for (int i = worksheet.Dimension.Start.Row; i <= worksheet.Dimension.End.Row; i++)
            {
                var cellValue = worksheet.Cells[i, 1].Value?.ToString();

                // Check if the cell in column A contains the search value
                if (cellValue != null && cellValue.ToLower() == searchValue.ToLower())
                {
                    // Return the value in column B for the matching row
                    var resultValue = worksheet.Cells[i, 2].Value?.ToString();

                    await ReplyAsync($"The value for {searchValue} is {resultValue}");
                    return;
                }
            }

            await ReplyAsync($"No matching value found for {searchValue}");
        }
    }
}
