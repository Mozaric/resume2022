# -*- coding: utf-8 -*-
"""
Created on Wed Mar 30 10:06:08 2022

@author: germa
"""

import matplotlib.pyplot as pyplot
import matplotlib.dates as dates
import datetime
import random

def GenerateArithmeticProgressionDataInteger(startValue, endValue, dataCount):
    """產生等差級數資料 (List)"""
    return [(int(startValue + int((endValue - startValue) / dataCount * i))) for i in range(dataCount)]

def GenerateRandomBatteryStep(highValue, lowValue, stepCount):
    """產生電量階梯資料 (List) ，例: [highValue, num1, num2, ..., lowValue] ，其中 num 值需介於 highValue 與 lowValue 之間"""
    interval = int((highValue - lowValue) / stepCount)
    basicValue = int(interval / 2)
    result = [lowValue + interval * i + random.randrange(1, interval - basicValue) for i in range(stepCount)]
    result.append(highValue)
    result.append(lowValue)
    result.sort()
    result.reverse()
    return result

def GenerateRandomTimestampStep(stepCount, dataCount):
    """產生時間戳資料 (List) ，例: [num1, num2, ..., numN] ，其中所有 num 的總和需等於 dataCount"""
    interval = int(dataCount / stepCount)
    basicValue = int(interval / 4 * 3)
    result = [basicValue + random.randrange(1, interval - basicValue) for i in range(stepCount - 1)]
    currentSum = sum(result)
    result.append(dataCount - currentSum)
    return result

def GenerateBatteryData(highValue, lowValue, dataCount, stepCount):
    """產生放電加充電的電量資料 (List)"""
    dischargeDataCount = int(dataCount / 4 * 3); # 3/4 的時間為 discharge
    chargeDataCount = dataCount - dischargeDataCount; # 1/4 的時間為 charge
    batteryStepCount = stepCount # 放電的階梯的次數
    timestampStepCount = batteryStepCount * 2
    
    result = []
    batteryStep = GenerateRandomBatteryStep(highValue, lowValue, batteryStepCount - 1)
    timestampStep = GenerateRandomTimestampStep(timestampStepCount, dischargeDataCount)
    
    # discharge data
    for i in range(len(batteryStep) - 1):
        result.extend(GenerateArithmeticProgressionDataInteger(batteryStep[i], batteryStep[i + 1], timestampStep[i * 2])) # 遞減
        result.extend(GenerateArithmeticProgressionDataInteger(batteryStep[i + 1], batteryStep[i + 1], timestampStep[i * 2 + 1])) # 持平
    
    # charge data
    result.extend(GenerateArithmeticProgressionDataInteger(lowValue, highValue, chargeDataCount - 60)) # 遞增
    result.extend(GenerateArithmeticProgressionDataInteger(highValue, highValue, 60)) # 持平
    
    return result

def GenerateTimestampData(dataCount):
    """產生時間戳資料，間隔為一分鐘，一天的資料量會是 1440 筆"""
    return [(datetime.datetime(2022, 1, 1, 0, 0, 0) + datetime.timedelta(minutes = i)) for i in range(dataCount)]

def GenerateRandomBatteryData(dataCount):
    """產生電量資料 (List) ，做兩次的放電+充電"""
    subDataCount1 = int(dataCount / 2 + random.randrange(-200, 200))
    subDataCount2 = dataCount - subDataCount1
    result = []
    result += GenerateBatteryData(100, 30 + random.randrange(-10, 10), subDataCount1, 5)
    result += GenerateBatteryData(100, 30 + random.randrange(-10, 10), subDataCount2, 5)
    return result

dataCount = 1440

timestamps = GenerateTimestampData(dataCount)
robotData1 = GenerateRandomBatteryData(dataCount)
robotData2 = GenerateRandomBatteryData(dataCount)

pyplot.figure(figsize = (16, 8), dpi = 100) # 設定圖片參數
pyplot.tick_params(axis = 'both', which = 'major', length = 10, labelsize = 20, pad = 10) # 坐標軸的文字與標線設定
pyplot.gca().xaxis.set_major_formatter(dates.DateFormatter('%H:%S')) # x 軸時間的格式設定
pyplot.ylim(-5, 105) # y 軸範圍設定
pyplot.grid(True, linestyle = '-.') # 格線顯示設定

pyplot.plot(timestamps, robotData1, color = 'r', label = 'Robot001')
pyplot.plot(timestamps, robotData2, color = 'b', label = 'Robot002')
pyplot.title('2022-01-01 Robot Battery Data', fontsize = 40)
pyplot.xlabel('Timestamp', fontsize = 30, labelpad = 10)
pyplot.ylabel('Battery (%)', fontsize = 30, labelpad = 10)
pyplot.legend(loc = 'best', fontsize = 20)

pyplot.show()
