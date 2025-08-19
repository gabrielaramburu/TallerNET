for i in {1..100}; do
  ab -n 1 -c 1 http://localhost:8080/api/vehiculos && sleep 1  # 1 segundo de delay
done
