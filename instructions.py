import sys
from PyQt5.QtWidgets import QPushButton, QLabel, QApplication, QWidget
from PyQt5.QtGui import QFont, QColor, QPalette, QPixmap
from PyQt5 import QtCore


class Instructions(QWidget):

    def __init__(self):
        super().__init__()
        self.initUI()

    def initUI(self):
        quitButton = QPushButton('Close Window', self)
        quitButton.clicked.connect(self.close)
        quitButton.resize(quitButton.sizeHint())
        quitButton.move(550, 20)
        label = QLabel("Instructions", self)
        label.setFont(QFont('SansSerif', 25))
        label.move(275, 50)
        self.instructions()
        self.images()
        pal = QPalette(label.palette())
        pal.setColor(QPalette.WindowText, QColor(56, 71, 73))
        self.setAutoFillBackground(True)
        p = self.palette()
        p.setColor(self.backgroundRole(), QColor(184, 216, 216))
        self.setPalette(p)
        self.setFixedSize(700, 750)
        self.setWindowTitle("Instructions Screen")
        self.show()

    # Write instructions to Instructions Window
    def instructions(self):
        l1 = QLabel("Game play is very similar to regular tic-tac toe but now with more\nways to win!", self)
        l1.setFont(QFont('SansSerif', 16))
        l1.move(30, 110)
        l2 = QLabel("You click a sqare to make your move", self)
        l2.setFont(QFont('SansSerif', 16))
        l2.move(30, 180)
        l3 = QLabel("You must get 4 in a row to win, diagonally, vertically or horizontally", self)
        l3.setFont(QFont('SansSerif', 16))
        l3.move(30, 220)
        l4 = QLabel("Some of the wins can be hard to see, so below are some examples:", self)
        l4.setFont(QFont('SansSerif', 16))
        l4.move(30, 260)

    # Print images to Instructions Window
    def images(self):
        p1 = QLabel(self)
        pixmap1 = QPixmap('win1.png')
        pixmap1 = pixmap1.scaled(315, 300, QtCore.Qt.KeepAspectRatio)
        p1.setPixmap(pixmap1)
        p1.move(25, 330)
        p2 = QLabel(self)
        pixmap2 = QPixmap('win2.png')
        pixmap2 = pixmap2.scaled(315, 300, QtCore.Qt.KeepAspectRatio)
        p2.setPixmap(pixmap2)
        p2.move(350, 330)


if __name__ == '__main__':
    app = QApplication(sys.argv)
    instruct = Instructions()
    sys.exit(app.exec_())
