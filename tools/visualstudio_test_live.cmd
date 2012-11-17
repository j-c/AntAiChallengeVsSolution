@echo off
SET PATH=%PATH%;C:\Program Files (x86)\Python27
python "%~dp0playgame.py" -So --turntime 3600000 --loadtime 3600000 --engine_seed 42 --player_seed 42 --end_wait=0.25 --verbose --log_dir game_logs --turns 1000 --map_file "%~dp0maps\example\tutorial1.map" "python ""%~dp0sample_bots\python\LeftyBot.py""" "%1" | java -jar visualizer.jar