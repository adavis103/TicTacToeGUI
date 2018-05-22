import sys
from PyQt5 import QtGui, QtCore
from PyQt5.QtCore import Qt
from PyQt5.QtWidgets import QHeaderView, QHBoxLayout, QVBoxLayout, QTableWidget, QTableWidgetItem, QApplication, QLabel, QWidget, QPushButton, QToolTip, QMessageBox
from PyQt5.QtGui import QFont, QPen, QColor, QPalette, QIcon
from board import Win, Point, Board



class ScoreScreen(QWidget):

    def __init__(self):
        super().__init__()
        self.setAutoFillBackground(True)
        background = self.palette()
        background.setColor(self.backgroundRole(), QColor(184, 216, 216))

        self.setPalette(background)
        self.setWindowTitle("High Scores Screen")
        self.setFixedSize(700, 750)

        titleFont = QFont('Sans Sarif', 24)
        titleFont.setBold(True)
        label = QLabel("High Scores", self)
        label.setFont(titleFont)
        label.move(250, 50)

        self.initUI()

    def initUI(self):

        quitButton = QPushButton('Close Window', self) # make quit button
        quitButton.setToolTip("Quit the game to the main menu")
        quitButton.clicked.connect(self.close)
        quitButton.move(550, 20)

        #Read first five lines of scores file
        file = open("highscores.txt") # read high score file

        score1 = file.readline()
        score2 = file.readline()
        score3 = file.readline()
        score4 = file.readline()
        score5 = file.readline()

        row1 = QTableWidgetItem(score1) # row items for table data
        row2 = QTableWidgetItem(score2)
        row3 = QTableWidgetItem(score3)
        row4 = QTableWidgetItem(score4)
        row5 = QTableWidgetItem(score5)

        #Insert into Table
        scoreTable = QTableWidget(self) # make table
        scoreTable.setRowCount(5)
        scoreTable.setColumnCount(1)
        scoreTable.setItem(0, 0, row1)
        scoreTable.setItem(1, 0, row2)
        scoreTable.setItem(2, 0, row3)
        scoreTable.setItem(3, 0, row4)
        scoreTable.setItem(4, 0, row5)
        scoreTable.verticalHeader().setVisible(False) # hide table headers
        scoreTable.horizontalHeader().setVisible(False)

        for i in range(0, 5):   # fill each cell with color
            scoreTable.item(i, 0).setBackground(QColor(184, 216, 216))
            scoreTable.item(i, 0).setFont(QFont('Sans Serif', 18))

        horizontalLayout = QHBoxLayout() # properly size table
        horizontalLayout.addWidget(scoreTable)
        verticalLayout = QVBoxLayout()
        verticalLayout.addWidget(scoreTable)
        horizontalLayout.addStretch()
        verticalLayout.addStretch()
        scoreTable.horizontalHeader().setSectionResizeMode(QHeaderView.Stretch)
        scoreTable.verticalHeader().setSectionResizeMode(QHeaderView.Stretch)

        scoreTable.move(225, 120)

        self.show()

    #Adds new score and sorts all scores
    @staticmethod
    def updateScores(initials):
        scores = {}
        file = open("highscores.txt", 'r')
        for line in file:
            name, score = line.split()
            print(name,score)
            scores[name] = int(score)

        if initials not in scores.keys():
            scores[initials] = 0
        scores[initials] = scores[initials] + 1

        print(scores)
        #Get top five scores
        file = open("highscores.txt", 'w')
        for key, value in sorted(scores.items(), key = lambda item: (item[1], item[0]), reverse=True):
            file.write(key + ' ' + str(value) + '\n')


if __name__ == '__main__':
    app = QApplication(sys.argv)
    ScrScreen = ScoreScreen()
    sys.exit(app.exec_())
    #ScoreScreen.updateScores('NM')
