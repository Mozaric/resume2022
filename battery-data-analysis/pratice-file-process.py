import datetime

class RobotData:
    def __init__(self, timestamp, name, battery):
        self.timestamp = timestamp
        self.name = name
        self.battery = battery
        
    def __str__(self):
        return 'timestamp: ' + self.timestamp.strftime('%Y-%m-%d %H:%M:%S') + ', name: ' + self.name + ', battery: ' + str(self.battery)
        
    @staticmethod
    def fromString(data):
        """將符合格式的字串轉換成 RobotData ，例： 2022-02-01 14:25:40,Robot01,100"""
        datas = data.split(',')
        timestamp = datetime.datetime.strptime(datas[0], '%Y-%m-%d %H:%M:%S')
        name = datas[1]
        battery = int(datas[2])
        return RobotData(timestamp, name, battery)

filePath = 'battery.csv'
robotDataCollection = []

f = open(filePath, 'r')
for line in f:
    robotDataCollection.append(RobotData.fromString(line))
f.close()

for i in range(len(robotDataCollection)):
    print(str(robotDataCollection[i]))
