using Discord.Commands;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FuzzySharp;

public class ExcelCommands : ModuleBase<SocketCommandContext>
{
    [Command("excel")]
    public async Task ExcelLookup(string query)
    {
        var worksheetName = "Sheet1";
        var executingAssemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
        var directory = Path.GetDirectoryName(executingAssemblyLocation);
        var path = Path.Combine(directory, "ExcelFile.xlsx");
        var fileInfo = new FileInfo(path);
        if (!fileInfo.Exists)
        {
            await ReplyAsync("Excel file not found.");
            return;
        }

        // Load the Excel file using EPPlus
        using (var package = new ExcelPackage(fileInfo))
        {
            var worksheet = package.Workbook.Worksheets[worksheetName];
            var foundMatch = false;

            // Loop through all cells in column A, looking for a match with the query
            foreach (var cell in worksheet.Cells["A:A"])
            {
                var matchScore = Fuzz.Ratio(cell.Text, query);

                // If the match score is above a certain threshold, consider it a match
                if (matchScore >= 70)
                {
                    var row = cell.Start.Row;
                    var value = worksheet.Cells[row, 2].Text;
                    await ReplyAsync(value);
                    foundMatch = true;
                    break;
                }
            }

            if (!foundMatch)
            {
                await ReplyAsync($"No match found for '{query}'.");
            }
        }
    }
}
