
// ЗАДАЧА 27 В функции можно использовать функции ее уровня и на один ниже

// Проведите рефакторинг - https://gist.github.com/HolyMonkey/adcf9478bd6dcdd21384bf269155f8fe

// pasportNumber переведен из int в string ? т.к. Серия Паспорта может быть не только цифровая

private SQLiteConnection ConnectSQLite(string connectionString)
{
    try
    {
        return connection = new SQLiteConnection(connectionString);
    }
    catch (SQLiteException ex)
    {
        if (ex.ErrorCode == 1)
        {
            int num2 = (int) MessageBox.Show("Файл db.sqlite не найден. Положите файл в папку вместе с exe.");
        }
        throw new InvalidOperationException("Не можем подсоединится к SQLite.");
    }
}   

private string GetConnectionString()
{
    return string.Format("Data Source=" + Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\db.sqlite");
}   

private string GetCommand(string pasportNumber)
{
    //  TODO: limit 1 блокирует ситуацию, когда возможно придет 2 записи, а это ошибка
    //  или num должен быть как ключевое поле таблицы passports. Проверить! 
    return string.Format("select * from passports where num='{0}' limit 1;", (object)Form1.ComputeSha256Hash(pasportNumber));
}   

private bool PackPasportNumber(string pasportNumber)
{
    return pasportNumber.Trim().Replace(" ", string.Empty);
}
private bool IsValidPasportNumber(string pasportNumber)
{
    if (pasportNumber.Length < 10)
    {
        return false;
    }
    return true;
}

private int GetPasportNumber()
{
    string pasportNumber = PackPasportNumber(this.passportTextbox.Text);
    if (pasportNumber == "")
    {
        pasportNumber = MessageBox.Show("Введите серию и номер паспорта");
    }

    return pasportNumber;
}

private bool? GetAccessRoleFromDB(string pasportNumber)
{
    SQLiteConnection connection = ConnectSQLite(GetConnectionString());
    connection.Open();
    SQLiteDataAdapter sqLiteDataAdapter = new SQLiteDataAdapter(new SQLiteCommand(GetCommand(pasportNumber), connection));
    DataTable dataTable = new DataTable();
    sqLiteDataAdapter.Fill(dataTable);

    // TODO: Нельзя брать ItemArray[1], т.к. в select * на первом месте может приходить другое поле. Нужно обращаться к конкретно именованному полю!
    bool? result = dataTable.Rows.Count > 0 ? Convert.ToBoolean(dataTable.Rows[0].ItemArray[1]) : null;

    connection.Close();

    return result;
}

private string GetAccessRole(string pasportNumber)
{
    bool? role = GetAccessRoleFromDB(pasportNumber);
    if (role == null)
    {
        return = $"Паспорт «{pasportNumber}» в списке участников дистанционного голосования НЕ НАЙДЕН";
    }

    if (role)
    {
        return $"По паспорту «{pasportNumber}» доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН";
    }
    else
    {
        return $"По паспорту «{pasportNumber}» доступ к бюллетеню на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ";
    }
}

private string SetVouteAccessRole()
{
    string pasportNumber = GetPasportNumber();

    if (IsValidPasportNumber(pasportNumber))
        return "Неверный формат серии или номера паспорта";

    return GetAccessRole(pasportNumber);
}


private void checkButton_Click(object sender, EventArgs e)
{
    this.textResult.Text = SetVouteAccessRole();
}