import requests
import time
import random
import _thread
from itertools import cycle

w = input("Digite o link de convite do servidor:")
x = input("Digite o id do canal de texto:")
z = input("Digite sua mensagem:")
y = float(0.5)
filo = open('discord_token.txt', 'r')
token = filo.readlines()
tokencycle = cycle(token)
r1 = (len(token))
r = 0

while r <= r1:
    r = r + 1
    url1 = ("https://discord.com/api/v6/invites/{}".format(w[-6::]))
    headers1 = { 
    'Authorization': ((next(tokencycle)).replace('\n',''))
    }
    response1 = requests.request("POST", url1, headers=headers1)
    print(response1.text.encode('utf8'))

while 0 < 1:
 def spammer( threadName, delay):
    url = ("https://discord.com/api/v6/channels/{}/messages".format(x))
    payload = ("{\"content\":\"%s\",\"tts\":false}" % z)
    headers = {
    'Authorization': ((next(tokencycle)).replace('\n','')),
    'Content-Type': 'application/json',
    }
    file = open('proxy.txt', 'r')
    list = file.readlines()
    z1 = (len(list))
    a1 = (random.randrange(0, z1))
    x1 = (list[a1])
    p1 = {"https":x1.replace('\n','')}
    response = requests.request("POST", url, headers=headers, data = payload, proxies=p1)
    print(response.text.encode('utf8'))
 try: 
    _thread.start_new_thread( spammer, ("Thread-1", 4, ) )
    time.sleep(y/4)
    _thread.start_new_thread( spammer, ("Thread-2", 4, ) )
    time.sleep(y/4)
    _thread.start_new_thread( spammer, ("Thread-3", 4, ) )
    time.sleep(y/4)
    _thread.start_new_thread( spammer, ("Thread-4", 4, ) )
    time.sleep(y/4)
 except RuntimeError:
     print("ERROR")
