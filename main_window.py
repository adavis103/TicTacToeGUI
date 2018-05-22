from PyQt5.QtWidgets import QInputDialog, QDesktopWidget
from ScoreScreen import *
from game_screen import gameScreen
from instructions import *


def centerWindow(win):
    qr = win.frameGeometry()
    cp = QDesktopWidget().availableGeometry().center()
    qr.moveCenter(cp)
    win.move(qr.topLeft())

class mainWindow(QWidget):
    def __init__(self):

        super().__init__()

        # set background color
        self.setAutoFillBackground(True)
        p = self.palette()
        p.setColor(self.backgroundRole(), QColor('#B8D8D8'))
        self.setPalette(p)

        #set Window and Taskbar Icons
        self.setWindowIcon(QIcon('Resources/TicTacToe'))
        menuIcon = QLabel(self)
        menuIcon.setPixmap(QPixmap('Resources/MenuIcon.png'))
        menuIcon.move(150, 25)
        menuIcon.show()

        title = QLabel(self)
        title.setPixmap(QPixmap('Resources/Title.png'))
        title.move(175, 450)
        title.show()

        names = QLabel(self)
        names.setText('Team 10:    Alex Davis     Taylor Lockhart     Nick McKillip   Alex Hagel')
        names.setFont(QFont('Sans Serif', 12))
        names.move(110, 550)
        names.show()

        self.setFixedSize(700, 750)
        centerWindow(self)
        self.mainMenu()

    def mainMenu(self):

        layout = QHBoxLayout(self)
        buttons = ['Play', 'Instructions', 'High Scores', 'Quit']

        #Creaate each button and connect action
        for button in buttons:
            b = QPushButton(button, self)
            b.setFont(QFont('Sans Serif', 12))
            if button == 'Play':
                b.clicked.connect(self.play)
            elif button == 'Instructions':
                b.clicked.connect(self.instructions)
            elif button == 'High Scores':
                b.clicked.connect(self.highscores)
            elif button == 'Quit':
                b.clicked.connect(self.close)
            layout.addWidget(b)

        layout.setAlignment(Qt.AlignBottom)
        layout.setDirection(QHBoxLayout.Down)

        self.setWindowTitle('Main Menu')
        self.show()

    #Close Window box
    def closeEvent(self, event):

        reply = QMessageBox.question(
            self,
            'Quit',
            'Are you sure you want to quit?',
            QMessageBox.Yes | QMessageBox.No,
            QMessageBox.Yes)

        if reply == QMessageBox.Yes:
            event.accept()
        else:
            event.ignore()

    #Call gameboard
    def play(self):

        initials = 'test'
        while initials.__len__() > 3:
            initials, result = QInputDialog.getText(self, ' ', 'Enter your Initials (must be 3 letters or less): ')
            if result == False:
                return
            initials = str(initials).upper()

        game = gameScreen()
        game.setPlayerToX()
        game.setPlayerInitials(initials)
        centerWindow(game)

    #Call Instructions Window
    def instructions(self):
        self.inst = Instructions()
        centerWindow(self.inst)

    #Call High Scores Window
    def highscores(self):
        self.hs = ScoreScreen()
        centerWindow(self.hs)


if __name__ == '__main__':
    app = QApplication(sys.argv)
    w = mainWindow()
    sys.exit(app.exec_())
