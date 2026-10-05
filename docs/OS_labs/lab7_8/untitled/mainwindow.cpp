#include "mainwindow.h"
#include "ui_mainwindow.h"

#include <QFileDialog>
#include <QPushButton>
#include <QStatusBar>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
    , model(new QFileSystemModel(this))
    , pathLabel(new QLabel(this))
{
    ui->setupUi(this);

    ui->treeView->setModel(model);

    ui->statusbar->addWidget(pathLabel);

    connect(ui->ChDirBtn_2, &QPushButton::clicked,
            this, &MainWindow::chooseDirectory);

    connect(ui->treeView, &QTreeView::clicked,
            this, &MainWindow::showSelectedPath);
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::chooseDirectory()
{
    QString directory = QFileDialog::getExistingDirectory(
        this,
        "Choose Directory"
    );

    if (directory.isEmpty())
        return;

    model->setRootPath(directory);
    ui->treeView->setRootIndex(model->index(directory));

    pathLabel->setText(directory);
}

void MainWindow::showSelectedPath(const QModelIndex &index)
{
    QString path = model->filePath(index);
    pathLabel->setText(path);
}
