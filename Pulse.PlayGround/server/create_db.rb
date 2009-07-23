# function(doc) {
#    if(doc.document_type == 'observation'  
#       && doc.type=='cpu.usage.perminute'
#       && doc.api_key == 'C2AH567BG90C')
#    emit('average', parseFloat(doc.value) * 100);
# }