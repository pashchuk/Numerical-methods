__author__ = 'Eduard'
import sys

class MatrixLoader:

    def __init__(self,mode='file',filename='input.txt'):
        self.mode = mode
        self.fileName = filename
        self.matrix = []

    def getMatrix(self):
        if self.mode == 'file':
            self.__getFromFile()
        else:
            self.__getFromConsole()
        return self.matrix

    def __getFromFile(self):
        with open(self.fileName,'r') as file:
            for line in file:
                # self.matrix.append([int(x) for x in line.strip().split(' ')])
                self.matrix.append(map(lambda x: int(x), line.strip().split(' ')))

    def __getFromConsole(self):
        print 'Input matrix'
        line = raw_input()
        while len(line) != 0:
            self.matrix.append(map(lambda x: int(x),line.strip().split(' ')))
            line = raw_input()




loader = MatrixLoader(mode='console')
matrix = loader.getMatrix()
print matrix