# Программа для просмотре базы данных школы

## Использованные технологии
- .NET Framework v6.0
- Microsoft.EntityFrameworkCore.Sqlite v6.0.7

## Скачать полное .sln решение VisualStudio 2022
Загрузить полное решение можно по ссылке https://drive.google.com/drive/folders/1rLhJRebd6w41saokKUKcn3CeDe13gp-w?usp=sharing

## Актуальная версия программы
Актуальные версию программы можно найти во вкладке `Releases` (на данный момент это v1.0)

## Архитектура
`Assets` - дополнительные ресурсы (словарь .xaml со стилями)<br>
`Database` - классы, контекст для работы с базой данных <br>
`Resources` - ресурсы программы (изображения) <br>
`Model` - классы-модели <br>
`View` - страницы и окно приложения, .xaml разметка<br>
`ViewModel` - прослойка между View и Model (соединение данных к странице) <br>
