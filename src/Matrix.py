__author__ = 'Eduard'

class Matrix:

    def __init__(self,mode='file',filename='input.txt'):
        self.matrix = []
        self.fileName = filename
        if mode == 'file':
            self.__getFromFile()
        elif mode == 'console':
            self.__getFromConsole()


    def __getFromFile(self):
        with open(self.fileName,'r') as file:
            for line in file:
                # self.matrix.append([int(x) for x in line.strip().split(' ')])
                self.matrix.append(map(int, line.strip().split(' ')))

    def __getFromConsole(self):
        print 'Input matrix'
        line = raw_input()
        while len(line) != 0:
            self.matrix.append(map(int,line.strip().split(' ')))
            line = raw_input()

    def __str__(self):
        return '\n'.join(map(str,self.matrix))