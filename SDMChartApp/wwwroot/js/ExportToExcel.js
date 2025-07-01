window.exportJsonToXlsx = (jsonData, fileName) => {
    const wb = XLSX.utils.book_new();
    const data = JSON.parse(jsonData);

    // Extract headers from data
    const headers = Object.keys(data[0]);
    const headerRow = headers.map(header => ({
        v: header,
        t: 's',
        s: {
            font: { bold: true }
        }
    }));

    // Convert data without headers
    const ws = XLSX.utils.json_to_sheet(data, { skipHeader: true, origin: "A2" });

    // Insert styled header row manually at row 1 (A1, B1, C1, ...)
    headers.forEach((header, index) => {
        const cellRef = XLSX.utils.encode_cell({ r: 0, c: index });
        ws[cellRef] = {
            v: header,
            t: 's',
            s: {
                font: { bold: true }
            }
        };
    });

    // Adjust the sheet range to include the header row
    const dataRange = XLSX.utils.decode_range(ws['!ref']);
    dataRange.s.r = 0; // Start from row 0
    ws['!ref'] = XLSX.utils.encode_range(dataRange);

    // Add sheet to workbook and trigger download
    XLSX.utils.book_append_sheet(wb, ws, "Sheet1");
    XLSX.writeFile(wb, fileName);
};
