#!/bin/bash

set -e

export ROOT_HOME=$(cd `dirname "$0"` && cd .. && pwd)
export LEVELDB_HOME=$(cd $ROOT_HOME && cd vendor/leveldb && pwd)

if [[ "$1" == "clean" ]]; then
  echo --------------------
  echo Clean
  echo --------------------

  cd $LEVELDB_HOME
  git clean -fdx
  git reset --hard
fi

echo --------------------
echo Build LevelDB
echo --------------------

cd $LEVELDB_HOME
export LIBRARY_PATH=$SNAPPY_HOME/lib
export C_INCLUDE_PATH=$SNAPPY_HOME/include
export CPLUS_INCLUDE_PATH=$SNAPPY_HOME/include
[[ "$OSTYPE" == "msys" ]] && patch -N $LEVELDB_HOME/build_detect_platform $ROOT_HOME/patches/leveldb/build_detect_platform.windows.patch
[[ "$OSTYPE" == "msys" ]] && patch -N $LEVELDB_HOME/util/env_posix.cc $ROOT_HOME/patches/leveldb/env_posix.cc.windows.patch
[[ "$OSTYPE" == "msys" ]] && cp -f $ROOT_HOME/patches/leveldb/env_win.cc $LEVELDB_HOME/util/env_win.cc
[[ "$OSTYPE" == "msys" ]] && patch -N $LEVELDB_HOME/port/port.h $ROOT_HOME/patches/leveldb/port.h.windows.patch
[[ "$OSTYPE" == "msys" ]] && cp -f $ROOT_HOME/patches/leveldb/port_win.h $LEVELDB_HOME/port/port_win.h
[[ "$OSTYPE" == "msys" ]] && cp -f $ROOT_HOME/patches/leveldb/port_win.cc $LEVELDB_HOME/port/port_win.cc
make clean all

echo --------------------
echo Copy LevelDB library
echo --------------------

cd $LEVELDB_HOME

if [[ "$OSTYPE" == "darwin"* ]]; then
  LEVELDB_FILE=libleveldb.dylib
  LEVELDB_ARCH=darwin
  OUTPUT_LEVELDB_FILE=
elif [[ "$OSTYPE" == "linux"* ]]; then
  LEVELDB_FILE=libleveldb.so
  if [[ $(uname -m) == "x86_64" ]]; then
    LEVELDB_ARCH=linux-x86-64
  else
    LEVELDB_ARCH=linux-x86
  fi
  OUTPUT_LEVELDB_FILE=
elif [[ "$OSTYPE" == "msys" ]]; then
  LEVELDB_FILE=libleveldb.dll
  if [[ "$MSYSTEM" == "MINGW64" ]]; then
    LEVELDB_ARCH=win32-x86-64
  else
    LEVELDB_ARCH=win32-x86
  fi
  OUTPUT_LEVELDB_FILE=leveldb.dll
fi

mkdir -p $ROOT_HOME/leveldb-jna-native/src/main/resources/$LEVELDB_ARCH/
cp $LEVELDB_FILE $ROOT_HOME/leveldb-jna-native/src/main/resources/$LEVELDB_ARCH/$OUTPUT_LEVELDB_FILE
